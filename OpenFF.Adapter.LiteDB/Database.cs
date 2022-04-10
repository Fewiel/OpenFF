using LiteDB;
using OpenFF.DataAccessLayer;
using OpenFF.DataAccessLayer.Brigade;
using OpenFF.DataAccessLayer.Department;
using OpenFF.DataAccessLayer.Exceptions;
using OpenFF.DataAccessLayer.Group;
using OpenFF.DataAccessLayer.Qualification;
using OpenFF.DataAccessLayer.Rank;
using OpenFF.DataAccessLayer.User;

namespace OpenFF.Adapter.LiteDB;

public class Database : IDatabase, IDisposable
{
    private LiteDatabase? DB;

    private UserRepository? _userRepository;
    private RankRepository? _rankRepository;
    private DepartmentRepository? _departmentRepository;
    private BrigadeRepository? _brigadeRepository;
    private GroupRepository? _groupRepository;
    private QualificationRepository? _qualificationRepository;

    public IUserRepository UserRepository => _userRepository ?? throw new UnconfiguredDatabaseException();
    public IRankRepository RankRepository => _rankRepository ?? throw new UnconfiguredDatabaseException();
    public IDepartmentRepository DepartmentRepository => _departmentRepository ?? throw new UnconfiguredDatabaseException();
    public IBrigadeRepository BrigadeRepository => _brigadeRepository ?? throw new UnconfiguredDatabaseException();
    public IGroupRepository GroupRepository => _groupRepository ?? throw new UnconfiguredDatabaseException();
    public IQualificationRepository QualificationRepository => _qualificationRepository ?? throw new UnconfiguredDatabaseException();

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
        _departmentRepository = new DepartmentRepository(DB.GetCollection<Department>("Departments"));
        _brigadeRepository = new BrigadeRepository(DB.GetCollection<Brigade>("Brigardes"));
        _groupRepository = new GroupRepository(DB.GetCollection<Group>("Groups"));
        _qualificationRepository = new QualificationRepository(DB.GetCollection<Qualification>("Qualifications"));
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
        DB?.Dispose();
    }
}