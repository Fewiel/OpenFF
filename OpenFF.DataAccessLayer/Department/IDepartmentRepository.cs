using OpenFF.DataAccessLayer.Brigade;

namespace OpenFF.DataAccessLayer.Department;

public interface IDepartmentRepository : IRepositoryBase<IDepartment>
{
    IDepartment New(long id, string name, string street, string houseNbr, string additionalAddress,
        string city, string postalCode, string email, string phone, string domain);
}