using System;

class Company
{
    public string Name { get; private set; }
    public string Address { get; private set; }
    public People Manager { get; private set; }
    public string PhoneNum { get; private set; }
    public string WebSite { get; private set; }

    public Company(string name, string address, string PhoneNum, string WebSite, People manager)
    {
        this.Name = name;
        this.Address = address;
        this.PhoneNum = PhoneNum;
        this.WebSite = WebSite;
        Manager = manager;
    }

    public override string ToString()
    {
        return string.Format (Name + " " + Address + " " + PhoneNum + " "+ WebSite + " " + Manager);
    }
}
