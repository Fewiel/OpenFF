using LiteDB;
using OpenFF.DataAccessLayer;
using OpenFF.DataAccessLayer.Exceptions;
using OpenFF.DataAccessLayer.Rank;
using OpenFF.DataAccessLayer.User;

namespace OpenFF.Adapter.LiteDB;

public class Database : IDatabase, IDisposable
{
    private LiteDatabase? DB;

    private UserRepository? _userRepository;
    private RankRepository? _rankRepository;

    public IUserRepository UserRepository => _userRepository ?? throw new UnconfiguredDatabaseException();
    public IRankRepository RankRepository => _rankRepository ?? throw new UnconfiguredDatabaseException();

    public void Configure(string connectionString)
    {
        BsonMapper.Global.RegisterType(
            serialize: obj => new BsonDocument { ["DateTime"] = obj.DateTime.Ticks, ["Offset"] = obj.Offset.Ticks },
            deserialize: doc => new DateTimeOffset(doc["DateTime"].AsInt64, new TimeSpan(doc["Offset"].AsInt64)));

        BsonMapper.Global.Entity<User>()
            .DbRef(x => x.Rank, "Ranks")
            .Id(x => x.ID);

        BsonMapper.Global.Entity<Rank>()
            .Id(x => x.ID);

        DB = new LiteDatabase(connectionString);

        _userRepository = new UserRepository(DB.GetCollection<User>("Users"));
        _rankRepository = new RankRepository(DB.GetCollection<Rank>("Ranks"));
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
        DB?.Dispose();
    }
}