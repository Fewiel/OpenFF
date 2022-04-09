namespace OpenFF.DataAccessLayer.User;

public interface IUser
{
    long ID { get; }
    string Username { get; }
    string Password { get; }
    string Firstname { get; }
    string Lastname { get; }
    string Email { get; }
    string Phone { get; }
    DateTimeOffset Birthday { get; }
    long Rank { get; }
    string Street { get; }
    string HouseNbr { get; }
    string AdditionalAddress { get; }
    string City { get; }
    string PostalCode { get; }
    DateTimeOffset Created { get; }
    DateTimeOffset LastLogin { get; }
    DateTimeOffset LastChange { get; }
}