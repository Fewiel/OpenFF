using LiteDB;
using OneOf;
using OneOf.Types;
using OpenFF.DataAccessLayer.Brigade;
using OpenFF.DataAccessLayer.Department;
using OpenFF.DataAccessLayer.Exceptions;

namespace OpenFF.Adapter.LiteDB;

public class BrigadeRepository : IBrigadeRepository
{
    private readonly ILiteCollection<Brigade> Col;

    public BrigadeRepository(ILiteCollection<Brigade> col)
    {
        Col = col;
        Col.EnsureIndex(x => x.ID);
    }

    public void Create(IBrigade data)
    {
        if (data is not Brigade b)
            throw new UnsupportedDatabaseException();

        Col.Insert(b);
    }

    public void Delete(IBrigade data) => Col.Delete(data.ID);

    public void Delete(long id) => Col.Delete(id);

    public OneOf<IBrigade, None> Get(long id)
    {
        var b = Col.Include(x => x.Department).FindOne(x => x.ID == id);
        if (b == null)
            return new None();

        return b;
    }

    public IEnumerable<IBrigade> GetAll() => Col.Include(x => x.Department).FindAll();

    public long GetCount() => Col.LongCount();

    public long GetMaxID() => Col.Max();

    public long GetMinID() => Col.Min();

    public IEnumerable<IBrigade> GetRange(long offset, int amount, string orderField, bool orderAsc)
    {
        if (orderField == "ID")
            orderField = "_id";

        return Col.Include(x => x.Department).Query().OrderBy(orderField, orderAsc ? 1 : 0)
            .Skip((int)offset).Limit(amount).ToEnumerable();
    }

    public IBrigade New(long id, string name, IDepartment department, string street, string HouseNbr, 
        string additionalAddress, string city, string postalCode, string email, string phone)
    {
        return new Brigade(id, name, department, street, HouseNbr, additionalAddress, city,
            postalCode, email, phone);
    }

    public void Update(IBrigade data)
    {
        if (data is not Brigade b)
            throw new UnsupportedDatabaseException();

        Col.Update(b);
    }
}