using LiteDB;
using OpenFF.DataAccessLayer.Brigade;
using OpenFF.DataAccessLayer.Department;

namespace OpenFF.Adapter.LiteDB;

public class Brigade : IBrigade
{
    public long ID { get; set; }
    public string Name { get; set; }
    public IDepartment Department { get; set; }
    public string Street { get; set; }
    public string HouseNbr { get; set; }
    public string AdditionalAddress { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

    [BsonCtor]
#pragma warning disable CS8618 // Ein Non-Nullable-Feld muss beim Beenden des Konstruktors einen Wert ungleich NULL enthalten. Erwägen Sie die Deklaration als Nullable.
    private Brigade() { }
#pragma warning restore CS8618 // Ein Non-Nullable-Feld muss beim Beenden des Konstruktors einen Wert ungleich NULL enthalten. Erwägen Sie die Deklaration als Nullable.

    public Brigade(long iD, string name, IDepartment department, string street, string houseNbr,
        string additionalAddress, string city, string postalCode, string email, string phone)
    {
        ID = iD;
        Name = name;
        Department = department;
        Street = street;
        HouseNbr = houseNbr;
        AdditionalAddress = additionalAddress;
        City = city;
        PostalCode = postalCode;
        Email = email;
        Phone = phone;
    }
}
