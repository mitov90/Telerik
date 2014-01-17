using System;

class Empoyee: People
{
    uint idNum;
    uint employeeNum;
    
    public Empoyee(string firstName, string familyName, Gendre gen, byte age,uint id, uint eNum)
        :base(firstName,familyName,gen,age)
    {
        this.idNum = id;
        this.employeeNum = eNum;
    }
    public override string ToString()
    {
        return base.ToString() +" "+ idNum.ToString() + " " + employeeNum.ToString();
    }
}

