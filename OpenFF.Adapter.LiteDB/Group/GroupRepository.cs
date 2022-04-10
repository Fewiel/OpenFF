using LiteDB;
using OneOf;
using OneOf.Types;
using OpenFF.DataAccessLayer.Department;
using OpenFF.DataAccessLayer.Exceptions;
using OpenFF.DataAccessLayer.Group;

namespace OpenFF.Adapter.LiteDB;

public class GroupRepository : IGroupRepository
{
    private readonly ILiteCollection<Group> Col;

    public GroupRepository(ILiteCollection<Group> col)
    {
        Col = col;
        Col.EnsureIndex(x => x.ID);
    }

    public void Create(IGroup data)
    {
        if (data is not Group g)
            throw new UnsupportedDatabaseException();

        Col.Insert(g);
    }

    public void Delete(IGroup data) => Col.Delete(data.ID);

    public void Delete(long id) => Col.Delete(id);

    public OneOf<IGroup, None> Get(long id)
    {
        var g = Col.Include(x => x.Department).FindOne(x => x.ID == id);
        if (g == null)
            return new None();

        return g;
    }

    public IEnumerable<IGroup> GetAll() => Col.Include(x => x.Department).FindAll();

    public long GetCount() => Col.LongCount();

    public long GetMaxID() => Col.Max();

    public long GetMinID() => Col.Min();

    public IEnumerable<IGroup> GetRange(long offset, int amount, string orderField, bool orderAsc)
    {
        if (orderField == "ID")
            orderField = "_id";

        return Col.Include(x => x.Department).Query().OrderBy(orderField, orderAsc ? 1 : 0)
            .Skip((int)offset).Limit(amount).ToEnumerable();
    }

    public IGroup New(long id, string name, IDepartment department)
    {
        return new Group(id, name, department);
    }

    public void Update(IGroup data)
    {
        if (data is not Group g)
            throw new UnsupportedDatabaseException();

        Col.Update(g);
    }
}