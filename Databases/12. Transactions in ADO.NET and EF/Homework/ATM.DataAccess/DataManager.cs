namespace ATM.DataAccess
{
    using System;
    using System.Linq;
    using System.Transactions;

    using ATM.Model;

    public class DataManager
    {
        private readonly ATMEntities atmContext;

        public DataManager(ATMEntities atmContext)
        {
            this.atmContext = atmContext;
        }

        public ATMOperationResult WithdrawMoney(string cardNumber, string cardPIN, decimal amount)
        {
            var options = new TransactionOptions
                              {
                                  IsolationLevel = IsolationLevel.RepeatableRead, 
                                  Timeout = new TimeSpan(0, 0, 0, 10)
                              };

            using (var scope = new TransactionScope(TransactionScopeOption.RequiresNew, options))
            {
                var account = this.atmContext.CardAccounts.FirstOrDefault(a => a.CardNumber == cardNumber);

                if (account == null)
                {
                    return ATMOperationResult.CardNumberInvalid;
                }

                if (account.CardPIN != cardPIN)
                {
                    return ATMOperationResult.CardPINInvalid;
                }

                if (account.CardCash <= amount)
                {
                    return ATMOperationResult.CashInsufficient;
                }

                account.CardCash -= amount;
                this.atmContext.SaveChanges();

                this.SaveTransactionHistory(cardNumber, amount);

                scope.Complete();

                return ATMOperationResult.Success;
            }
        }

        public ATMOperationResult GetCardCash(string cardNumber, string cardPIN, out decimal cash)
        {
            cash = 0.0M;

            var options = new TransactionOptions
                              {
                                  IsolationLevel = IsolationLevel.RepeatableRead, 
                                  Timeout = new TimeSpan(0, 0, 0, 10)
                              };

            using (var scope = new TransactionScope(TransactionScopeOption.RequiresNew, options))
            {
                var account = this.atmContext.CardAccounts.FirstOrDefault(a => a.CardNumber == cardNumber);

                if (account == null)
                {
                    return ATMOperationResult.CardNumberInvalid;
                }

                if (account.CardPIN != cardPIN)
                {
                    return ATMOperationResult.CardPINInvalid;
                }

                cash = account.CardCash;

                scope.Complete();

                return ATMOperationResult.Success;
            }
        }

        public void InsertCardAccount(string cardNumber, string cardPIN, decimal cash)
        {
            var options = new TransactionOptions
                              {
                                  IsolationLevel = IsolationLevel.RepeatableRead, 
                                  Timeout = new TimeSpan(0, 0, 0, 10)
                              };

            using (var scope = new TransactionScope(TransactionScopeOption.RequiresNew, options))
            {
                var account = new CardAccount { CardNumber = cardNumber, CardPIN = cardPIN, CardCash = cash };

                this.atmContext.CardAccounts.Add(account);
                this.atmContext.SaveChanges();

                scope.Complete();
            }
        }

        private void SaveTransactionHistory(string cardNumber, decimal amount)
        {
            var options = new TransactionOptions
                              {
                                  IsolationLevel = IsolationLevel.RepeatableRead, 
                                  Timeout = new TimeSpan(0, 0, 0, 10)
                              };

            using (var scope = new TransactionScope(TransactionScopeOption.Required, options))
            {
                var transactionInfo = new TransactionsHistory
                                          {
                                              CardNumber = cardNumber, 
                                              TransactionDate = DateTime.Now, 
                                              Amount = amount
                                          };

                this.atmContext.TransactionsHistories.Add(transactionInfo);
                this.atmContext.SaveChanges();

                scope.Complete();
            }
        }
    }
}