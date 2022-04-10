using LiteDB;
using OneOf;
using OneOf.Types;
using OpenFF.DataAccessLayer.Department;
using OpenFF.DataAccessLayer.Exceptions;

namespace OpenFF.Adapter.LiteDB;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly ILiteCollection<Department> Col;

    public DepartmentRepository(ILiteCollection<Department> col)
    {
        Col = col;
        Col.EnsureIndex(x => x.ID);
    }

    public void Create(IDepartment data)
    {
        if (data is not Department d)
            throw new UnsupportedDatabaseException();

        Col.Insert(d);
    }

    public void Delete(IDepartment data) => Col.Delete(data.ID);

    public void Delete(long id) => Col.Delete(id);

    public OneOf<IDepartment, None> Get(long id)
    {
        var d = Col.FindOne(x => x.ID == id);
        if (d == null)
            return new None();

        return d;
    }

    public IEnumerable<IDepartment> GetAll() => Col.FindAll();

    public long GetCount() => Col.LongCount();

    public long GetMaxID() => Col.Max();

    public long GetMinID() => Col.Min();

    public IEnumerable<IDepartment> GetRange(long offset, int amount, string orderField, bool orderAsc)
    {
        if (orderField == "ID")
            orderField = "_id";

        return Col.Query().OrderBy(orderField, orderAsc ? 1 : 0).Skip((int)offset).Limit(amount).ToEnumerable();
    }

    public IDepartment New(long id, string name, string street, string houseNbr, string additionalAddress,
        string city, string postalCode, string email, string phone, string domain)
    {
        return new Department(id, name, street, houseNbr, additionalAddress, city, postalCode, email, phone, domain);
    }

    public void Update(IDepartment data)
    {
        if (data is not Department d)
            throw new UnsupportedDatabaseException();

        Col.Update(d);
    }
}