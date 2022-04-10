namespace OpenFF.DataAccessLayer.Rank;

public interface IRankRepository : IRepositoryBase<IRank>
{
    IRank New(long id, string name, string picture);
}