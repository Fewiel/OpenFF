using OpenFF.DataAccessLayer.Department;

namespace OpenFF.DataAccessLayer.Group;

public interface IGroup
{
    long ID { get; }
    string Name { get; }
    IDepartment Department { get; }
}