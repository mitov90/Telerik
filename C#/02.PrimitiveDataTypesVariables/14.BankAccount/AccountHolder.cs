using System;

class AccountHolder
{
    string firstName;
    string lastName;
    string middleName;

    public AccountHolder(string fName,string mName,string lName)
    {
        this.firstName = fName;
        this.lastName = lName;
        this.middleName = mName;
    }

    public override string ToString()
    {
        return string.Format (firstName + " " + middleName + " " + lastName);
    }
}
