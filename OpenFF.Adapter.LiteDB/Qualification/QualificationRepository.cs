using LiteDB;
using OneOf;
using OneOf.Types;
using OpenFF.DataAccessLayer.Exceptions;
using OpenFF.DataAccessLayer.Qualification;
using OpenFF.DataAccessLayer.Rank;

namespace OpenFF.Adapter.LiteDB;

internal class QualificationRepository : IQualificationRepository
{
    private readonly ILiteCollection<Qualification> Col;

    public QualificationRepository(ILiteCollection<Qualification> col)
    {
        Col = col;
        Col.EnsureIndex(x => x.ID);
    }

    public void Create(IQualification data)
    {
        if (data is not Qualification q)
            throw new UnsupportedDatabaseException();

        Col.Insert(q);
    }

    public void Delete(IQualification data) => Col.Delete(data.ID);

    public void Delete(long id) => Col.Delete(id);

    public OneOf<IQualification, None> Get(long id)
    {
        var q = Col.FindOne(x => x.ID == id);
        if (q == null)
            return new None();

        return q;
    }

    public IEnumerable<IQualification> GetAll() => Col.FindAll();

    public long GetCount() => Col.LongCount();

    public long GetMaxID() => Col.Max();

    public long GetMinID() => Col.Min();

    public IEnumerable<IQualification> GetRange(long offset, int amount, string orderField, bool orderAsc)
    {
        if (orderField == "ID")
            orderField = "_id";

        return Col.Query().OrderBy(orderField, orderAsc ? 1 : 0).Skip((int)offset).Limit(amount).ToEnumerable();
    }

    public IQualification New(long id, string name, bool displayed)
    {
        return new Qualification(id, name, displayed);
    }

    public void Update(IQualification data)
    {
        if (data is not Qualification q)
            throw new UnsupportedDatabaseException();

        Col.Update(q);
    }
}