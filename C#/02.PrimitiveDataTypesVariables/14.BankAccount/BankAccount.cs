using System;

class BankAccount
{
    public AccountHolder Holder{get; private set;}
    public decimal Balance { get; private set; }
    public string iban { get; private set; }
    public Bank bank { get; private set; }
    public ushort creditCard { get; private set; }

    public BankAccount(AccountHolder holder, decimal balance, string iban, Bank bank, ushort creditCard)
    {
        this.Holder = holder;
        this.Balance = balance;
        this.iban = iban;
        this.bank = bank;
        this.creditCard = creditCard;
    }

    public override string ToString()
    {
        return string.Format(Holder.ToString() + " " + bank.ToString() + " Balance:" + Balance + " IBAN:" + iban);
    }
}

