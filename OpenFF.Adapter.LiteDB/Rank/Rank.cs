using LiteDB;
using OpenFF.DataAccessLayer.Rank;

namespace OpenFF.Adapter.LiteDB;

public class Rank : IRank
{
    public long ID { get; set; }
    public string Name { get; set; }
    public string Picture { get; set; }

    [BsonCtor]
#pragma warning disable CS8618 // Ein Non-Nullable-Feld muss beim Beenden des Konstruktors einen Wert ungleich NULL enthalten. Erwägen Sie die Deklaration als Nullable.
    private Rank() { }
#pragma warning restore CS8618 // Ein Non-Nullable-Feld muss beim Beenden des Konstruktors einen Wert ungleich NULL enthalten. Erwägen Sie die Deklaration als Nullable.

    public Rank(long iD, string name, string picture)
    {
        ID = iD;
        Name = name;
        Picture = picture;
    }
}