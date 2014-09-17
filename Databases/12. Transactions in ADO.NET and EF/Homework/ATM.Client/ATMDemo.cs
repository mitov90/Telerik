namespace ATM.Client
{
    using System;

    using ATM.DataAccess;
    using ATM.Model;

    internal class ATMDemo
    {
        private static void Main()
        {
            var dataManager = new DataManager(new ATMEntities());

            var withdrawResult = dataManager.WithdrawMoney("9273412345", "8356", 200);

            if (withdrawResult == ATMOperationResult.Success)
            {
                decimal cardCash;
                var retrieveResult = dataManager.GetCardCash("9273412345", "8356", out cardCash);

                if (retrieveResult == ATMOperationResult.Success)
                {
                    Console.WriteLine("Remaining cash: {0:N2}", cardCash);
                }
            }
        }
    }
}