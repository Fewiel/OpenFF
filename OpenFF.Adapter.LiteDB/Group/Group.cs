using LiteDB;
using OpenFF.DataAccessLayer.Department;
using OpenFF.DataAccessLayer.Group;

namespace OpenFF.Adapter.LiteDB;

public class Group : IGroup
{
    public long ID { get; set; }
    public string Name { get; set; }
    public IDepartment Department { get; set; }

    [BsonCtor]
#pragma warning disable CS8618 // Ein Non-Nullable-Feld muss beim Beenden des Konstruktors einen Wert ungleich NULL enthalten. Erwägen Sie die Deklaration als Nullable.
    private Group() { }
#pragma warning restore CS8618 // Ein Non-Nullable-Feld muss beim Beenden des Konstruktors einen Wert ungleich NULL enthalten. Erwägen Sie die Deklaration als Nullable.

    public Group(long iD, string name, IDepartment department)
    {
        ID = iD;
        Name = name;
        Department = department;
    }
}