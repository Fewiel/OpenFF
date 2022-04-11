using OpenFF.DataAccessLayer.User;

namespace OpenFF.DataAccessLayer.Appointment;

public interface IAppointmentRepository : IRepositoryBase<IAppointment>
{
    IAppointment New(long id, IUser user, string street, string houseNbr, string additionalAddress,
        string postalCode, string city, DateTimeOffset dateTimeCreated, DateTimeOffset dateTimeStart,
        DateTimeOffset dateTimeEnd, string name, string description, bool attendance, bool cancelled);
}