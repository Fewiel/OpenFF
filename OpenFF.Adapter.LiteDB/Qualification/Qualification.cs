using LiteDB;
using OpenFF.DataAccessLayer.Qualification;

namespace OpenFF.Adapter.LiteDB;

public class Qualification : IQualification
{
    public long ID { get; set; }
    public string Name { get; set; }
    public bool Displayed { get; set; }

    [BsonCtor]
#pragma warning disable CS8618 // Ein Non-Nullable-Feld muss beim Beenden des Konstruktors einen Wert ungleich NULL enthalten. Erwägen Sie die Deklaration als Nullable.
    private Qualification() { }
#pragma warning restore CS8618 // Ein Non-Nullable-Feld muss beim Beenden des Konstruktors einen Wert ungleich NULL enthalten. Erwägen Sie die Deklaration als Nullable.

    public Qualification(long iD, string name, bool displayed)
    {
        ID = iD;
        Name = name;
        Displayed = displayed;
    }
}