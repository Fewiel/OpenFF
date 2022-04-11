using OpenFF.DataAccessLayer.User;

namespace OpenFF.DataAccessLayer.Appointment;

public interface IAppointment
{
    long ID { get; }
    IUser User { get; }
    string Street { get; }
    string HouseNbr { get; }
    string AdditionalAddress { get; }
    string PostalCode { get; }
    string City { get; }
    DateTimeOffset DateTimeCreated { get; }
    DateTimeOffset DateTimeStart { get; }
    DateTimeOffset DateTimeEnd { get; }
    string Name { get; }
    string Description { get; }
    bool Attendance { get; }
    bool Cancelled { get; }
}