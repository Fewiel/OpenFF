using LiteDB;
using OpenFF.DataAccessLayer.Department;

namespace OpenFF.Adapter.LiteDB;

public class Department : IDepartment
{
    public long ID { get; set; }
    public string Name { get; set; }
    public string Street { get; set; }
    public string HouseNbr { get; set; }
    public string AdditionalAddress { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Domain { get; set; }

    [BsonCtor]
#pragma warning disable CS8618 // Ein Non-Nullable-Feld muss beim Beenden des Konstruktors einen Wert ungleich NULL enthalten. Erwägen Sie die Deklaration als Nullable.
    private Department() { }
#pragma warning restore CS8618 // Ein Non-Nullable-Feld muss beim Beenden des Konstruktors einen Wert ungleich NULL enthalten. Erwägen Sie die Deklaration als Nullable.

    public Department(long iD, string name, string street, string houseNbr,
        string additionalAddress, string city, string postalCode, string email,
        string phone, string domain)
    {
        ID = iD;
        Name = name;
        Street = street;
        HouseNbr = houseNbr;
        AdditionalAddress = additionalAddress;
        City = city;
        PostalCode = postalCode;
        Email = email;
        Phone = phone;
        Domain = domain;
    }
}