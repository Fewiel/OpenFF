using OpenFF.DataAccessLayer.Department;

namespace OpenFF.DataAccessLayer.Brigade;

public interface IBrigadeRepository : IRepositoryBase<IBrigade>
{
    IBrigade New(long id, string name, IDepartment department, string street,
        string HouseNbr, string additionalAddress, string city, string postalCode, string email, string phone);
}
