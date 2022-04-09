using OpenFF.DataAccessLayer.User;

namespace OpenFF.DataAccessLayer;

public interface IDatabase
{
    void Configure(string connectionString);

    IUserRepository UserRepository { get; }
}