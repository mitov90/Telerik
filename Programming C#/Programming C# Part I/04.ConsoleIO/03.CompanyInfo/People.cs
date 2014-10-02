using System;

class People
{
    string firstName;
    string lastName;
    string middleName;
    public byte Age { get; private set; }
    public string PhoneNumber { get; private set; }
    public People(string fName,string mName,string lName, byte age, string phone)
    {
        this.firstName = fName;
        this.lastName = lName;
        this.middleName = mName;
        this.Age = age;
        this.PhoneNumber = phone;
    }

    public override string ToString()
    {
        return string.Format (firstName + " " + middleName + " " + lastName + " " + Age + " " + PhoneNumber);
    }
}
