using OpenFF.DataAccessLayer.Department;

namespace OpenFF.DataAccessLayer.Groups;

public interface IGroup
{
    long ID { get; }
    string Name { get; }
    IDepartment Department { get; }
}