using System;

public class Student : IComparable<Student>
{
    public Student(string firstName, string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            throw new ArgumentException("First name cannot be null or empty.", "firstName");
        }

        if (string.IsNullOrWhiteSpace(lastName))
        {
            throw new ArgumentException("Last name cannot be null or empty.", "lastName");
        }

        this.FirstName = firstName;
        this.LastName = lastName;
    }

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public int CompareTo(Student other)
    {
        int compareResult = string.Compare(this.LastName, other.LastName, StringComparison.Ordinal);
        if (compareResult == 0)
        {
            compareResult = string.Compare(this.FirstName, other.FirstName, StringComparison.Ordinal);
        }

        return compareResult;
    }

    public override string ToString()
    {
        return string.Format(this.FirstName + " " + this.LastName);
    }
}
