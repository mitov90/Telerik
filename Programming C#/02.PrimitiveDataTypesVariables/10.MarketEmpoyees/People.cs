using System;

class People
{
    string firstName;
    string familyName;
    Gendre gen;
    byte age;

    public People(string firstName, string familyName, Gendre gen, byte age)
    {
        this.firstName = firstName;
        this.familyName = familyName;
        this.gen = gen;
        this.age = age;
    }

    public override string ToString()
    {
        return string.Format(firstName + " " + familyName + " " + gen + " Age:" + age);
    }
}
