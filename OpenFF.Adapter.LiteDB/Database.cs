using LiteDB;
using OpenFF.DataAccessLayer;
using OpenFF.DataAccessLayer.Exceptions;
using OpenFF.DataAccessLayer.User;

namespace OpenFF.Adapter.LiteDB;

public class Database : IDatabase, IDisposable
{
    private LiteDatabase? DB;

    private UserRepository? _userRepository;

    public IUserRepository UserRepository => _userRepository ?? throw new UnconfiguredDatabaseException();

    public void Configure(string connectionString)
    {
        BsonMapper.Global.RegisterType(
            serialize: obj => new BsonDocument { ["DateTime"] = obj.DateTime.Ticks, ["Offset"] = obj.Offset.Ticks },
            deserialize: doc => new DateTimeOffset(doc["DateTime"].AsInt64, new TimeSpan(doc["Offset"].AsInt64)));

        BsonMapper.Global.Entity<User>()
            .Id(x => x.ID);

        DB = new LiteDatabase(connectionString);

        _userRepository = new UserRepository(DB.GetCollection<User>("Users"));
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
        DB?.Dispose();
    }
}