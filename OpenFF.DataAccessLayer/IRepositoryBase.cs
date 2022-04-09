using OneOf;
using OneOf.Types;

namespace OpenFF.DataAccessLayer;

public interface IRepositoryBase<T>
{
    void Create(T data);
    void Update(T data);
    void Delete(T data);
    void Delete(long id);

    long GetMinID();
    long GetMaxID();
    long GetCount();

    IEnumerable<T> GetAll();
    IEnumerable<T> GetRange(long offset, int amount, string orderField, bool orderAsc);
    OneOf<T, None> Get(long id);
}
