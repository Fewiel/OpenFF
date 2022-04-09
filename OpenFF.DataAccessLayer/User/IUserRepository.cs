namespace OpenFF.DataAccessLayer.User;

public interface IUserRepository : IRepositoryBase<IUser>
{
    IUser New(long id, string username, string password, string firstname, string lastname,
        string email, string phone, DateTimeOffset birthday, long rank, string street,
        string houseNbr, string additionalAddress, string city, string postalCode,
        DateTimeOffset created, DateTimeOffset lastLogin, DateTimeOffset lastChange);
}