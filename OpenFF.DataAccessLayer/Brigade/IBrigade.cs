using OpenFF.DataAccessLayer.Department;

namespace OpenFF.DataAccessLayer.Brigade;

public interface IBrigade
{
    long ID { get; }
    string Name { get; }
    IDepartment Department { get; }
    string Street { get; }
    string HouseNbr { get; }
    string AdditionalAddress { get; }
    string City { get; }
    string PostalCode { get; }
    string Email { get; }
    string Phone { get; }
}