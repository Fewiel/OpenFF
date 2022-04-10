using LiteDB;
using OpenFF.DataAccessLayer.Rank;
using OpenFF.DataAccessLayer.User;

namespace OpenFF.Adapter.LiteDB;

public class User : IUser
{
    public long ID { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public DateTimeOffset Birthday { get; set; }
    public IRank Rank { get; set; }
    public string Street { get; set; }
    public string HouseNbr { get; set; }
    public string AdditionalAddress { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public DateTimeOffset DateTimeCreated { get; set; }
    public DateTimeOffset LastLogin { get; set; }
    public DateTimeOffset LastChange { get; set; }

    [BsonCtor]
#pragma warning disable CS8618 // Ein Non-Nullable-Feld muss beim Beenden des Konstruktors einen Wert ungleich NULL enthalten. Erwägen Sie die Deklaration als Nullable.
    private User() { }
#pragma warning restore CS8618 // Ein Non-Nullable-Feld muss beim Beenden des Konstruktors einen Wert ungleich NULL enthalten. Erwägen Sie die Deklaration als Nullable.

    public User(long id, string username, string password, string firstname, string lastname,
        string email, string phone, DateTimeOffset birthday, IRank rank, string street, string houseNbr,
        string additionalAddress, string city, string postalCode,
        DateTimeOffset dateTimeCreated, DateTimeOffset lastLogin, DateTimeOffset lastChange)
    {
        ID = id;
        Username = username;
        Password = password;
        Firstname = firstname;
        Lastname = lastname;
        Email = email;
        Phone = phone;
        Birthday = birthday;
        Rank = rank;
        Street = street;
        HouseNbr = houseNbr;
        AdditionalAddress = additionalAddress;
        City = city;
        PostalCode = postalCode;
        DateTimeCreated = dateTimeCreated;
        LastLogin = lastLogin;
        LastChange = lastChange;
    }
}