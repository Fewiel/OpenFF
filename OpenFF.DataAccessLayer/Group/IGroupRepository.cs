using OpenFF.DataAccessLayer.Department;

namespace OpenFF.DataAccessLayer.Group;

public interface IGroupRepository : IRepositoryBase<IGroup>
{
    IGroup New(long id, string name, IDepartment department);
}