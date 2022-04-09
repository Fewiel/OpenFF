using LiteDB;
using OneOf;
using OneOf.Types;
using OpenFF.DataAccessLayer.Exceptions;
using OpenFF.DataAccessLayer.User;

namespace OpenFF.Adapter.LiteDB;

public class UserRepository : IUserRepository
{
    private readonly ILiteCollection<User> Col;

    public UserRepository(ILiteCollection<User> col)
    {
        Col = col;
        Col.EnsureIndex(x => x.ID);
    }

    public void Create(IUser data)
    {
        if (data is not User u)
            throw new UnsupportedDatabaseException();

        Col.Insert(u);
    }

    public void Delete(IUser data) => Col.Delete(data.ID);

    public void Delete(long id) => Col.Delete(id);

    public OneOf<IUser, None> Get(long id)
    {
        var u = Col.FindOne(x => x.ID == id);
        if (u == null)
            return new None();

        return u;
    }

    public IEnumerable<IUser> GetAll() => Col.FindAll();

    public long GetCount() => Col.LongCount();

    public long GetMaxID() => Col.Max();

    public long GetMinID() => Col.Min();

    public IEnumerable<IUser> GetRange(long offset, int amount, string orderField, bool orderAsc)
    {
        if (orderField == "ID")
            orderField = "_id";

        return Col.Query().OrderBy(orderField, orderAsc ? 1 : 0).Skip((int)offset).Limit(amount).ToEnumerable();
    }

    public IUser New(long id, string username, string password, string firstname, string lastname,
        string email, string phone, DateTimeOffset birthday, long rank, string street, string houseNbr,
        string additionalAddress, string city, string postalCode,
        DateTimeOffset created, DateTimeOffset lastLogin, DateTimeOffset lastChange)
    {
        return new User(id, username, password, firstname, lastname, email, phone, birthday, rank,
            street, houseNbr, additionalAddress, city, postalCode, created, lastLogin, lastChange);
    }

    public void Update(IUser data)
    {
        if (data is not User u)
            throw new UnsupportedDatabaseException();

        Col.Update(u);
    }
}
