using LiteDB;
using OneOf;
using OneOf.Types;
using OpenFF.DataAccessLayer.Exceptions;
using OpenFF.DataAccessLayer.Rank;

namespace OpenFF.Adapter.LiteDB;

public class RankRepository : IRankRepository
{
    private readonly ILiteCollection<Rank> Col;

    public RankRepository(ILiteCollection<Rank> col)
    {
        Col = col;
        Col.EnsureIndex(x => x.ID);
    }

    public void Create(IRank data)
    {
        if (data is not Rank r)
            throw new UnsupportedDatabaseException();

        Col.Insert(r);
    }

    public void Delete(IRank data) => Col.Delete(data.ID);

    public void Delete(long id) => Col.Delete(id);

    public OneOf<IRank, None> Get(long id)
    {
        var r = Col.FindOne(x => x.ID == id);
        if (r == null)
            return new None();

        return r;
    }

    public IEnumerable<IRank> GetAll() => Col.FindAll();

    public long GetCount() => Col.LongCount();

    public long GetMaxID() => Col.Max();

    public long GetMinID() => Col.Min();

    public IEnumerable<IRank> GetRange(long offset, int amount, string orderField, bool orderAsc)
    {
        if (orderField == "ID")
            orderField = "_id";

        return Col.Query().OrderBy(orderField, orderAsc ? 1 : 0).Skip((int)offset).Limit(amount).ToEnumerable();
    }

    public IRank New(long id, string name, string picture)
    {
        return new Rank(id, name, picture);
    }

    public void Update(IRank data)
    {
        if (data is not User r)
            throw new UnsupportedDatabaseException();

        Col.Update(r);
    }
}