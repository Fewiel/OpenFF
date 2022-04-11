using LiteDB;
using OpenFF.DataAccessLayer.Appointment;
using OpenFF.DataAccessLayer.User;

namespace OpenFF.Adapter.LiteDB.Appointment;

public class Appointment : IAppointment
{
    public long ID { get; set; }
    public IUser User { get; set; }
    public string Street { get; set; }
    public string HouseNbr { get; set; }
    public string AdditionalAddress { get; set; }
    public string PostalCode { get; set; }
    public string City { get; set; }
    public DateTimeOffset DateTimeCreated { get; set; }
    public DateTimeOffset DateTimeStart { get; set; }
    public DateTimeOffset DateTimeEnd { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool Attendance { get; set; }
    public bool Cancelled { get; set; }

    [BsonCtor]
#pragma warning disable CS8618 // Ein Non-Nullable-Feld muss beim Beenden des Konstruktors einen Wert ungleich NULL enthalten. Erwägen Sie die Deklaration als Nullable.
    private Appointment() { }
#pragma warning restore CS8618 // Ein Non-Nullable-Feld muss beim Beenden des Konstruktors einen Wert ungleich NULL enthalten. Erwägen Sie die Deklaration als Nullable.

    public Appointment(long iD, IUser user, string street, string houseNbr,
        string additionalAddress, string postalCode, string city, DateTimeOffset dateTimeCreated,
        DateTimeOffset dateTimeStart, DateTimeOffset dateTimeEnd, string name, string description,
        bool attendance, bool cancelled)
    {
        ID = iD;
        User = user;
        Street = street;
        HouseNbr = houseNbr;
        AdditionalAddress = additionalAddress;
        PostalCode = postalCode;
        City = city;
        DateTimeCreated = dateTimeCreated;
        DateTimeStart = dateTimeStart;
        DateTimeEnd = dateTimeEnd;
        Name = name;
        Description = description;
        Attendance = attendance;
        Cancelled = cancelled;
    }
}