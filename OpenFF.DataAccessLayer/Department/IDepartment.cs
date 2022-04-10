using OpenFF.DataAccessLayer.Brigade;

namespace OpenFF.DataAccessLayer.Department;

public interface IDepartment
{
    long ID { get; }
    string Name { get; }
    string Street { get; }
    string HouseNbr { get; }
    string AdditionalAddress { get; }
    string City { get; }
    string PostalCode { get; }
    string Email { get; }
    string Phone { get; }
    string Domain { get; }
}