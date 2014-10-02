using System;

class Bank
{
    public string BankName { get; private set; }
    public string BicCode { get; private set; }

    public Bank(string name, string bic)
    {
        this.BankName = name;
        this.BicCode = bic;
    }

    public override string ToString()
    {
        return string.Format (BankName + " " + BicCode);
    }
}
