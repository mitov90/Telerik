using System;

class BankAccountTest
{
    static void Main()
    {
        BankAccount myAccount = new BankAccount(new AccountHolder("Gosgho", "Georgiev", "Georgiev"), 123.23M ,"BG93843293",
                                                new Bank("DSK", "DSKSF"), 123 );
        Console.WriteLine(myAccount);
    }
}
