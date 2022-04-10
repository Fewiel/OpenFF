using OpenFF.DataAccessLayer.Rank;

namespace OpenFF.DataAccessLayer.User;

public interface IUserRepository : IRepositoryBase<IUser>
{
    IUser New(long id, string username, string password, string firstname, string lastname,
        string email, string phone, DateTimeOffset birthday, IRank rank, string street,
        string houseNbr, string additionalAddress, string city, string postalCode,
        DateTimeOffset dateTimeCreated, DateTimeOffset lastLogin, DateTimeOffset lastChange);
}