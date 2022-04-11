using LiteDB;
using OneOf;
using OneOf.Types;
using OpenFF.DataAccessLayer.Appointment;
using OpenFF.DataAccessLayer.Exceptions;
using OpenFF.DataAccessLayer.User;
using System.Security.Cryptography.X509Certificates;

namespace OpenFF.Adapter.LiteDB.Appointment;

public class AppointmentRepository : IAppointmentRepository
{
    private readonly ILiteCollection<Appointment> Col;
    private readonly ILiteCollection<Appointment> BrigadeAppointments;
    private readonly ILiteCollection<Appointment> UserAppointments;

    public AppointmentRepository(ILiteCollection<Appointment> col)
    {
        Col = col;
        Col.EnsureIndex(x => x.ID);
    }

    public void Create(IAppointment data)
    {
        if (data is not Appointment a)
            throw new UnsupportedDatabaseException();

        Col.Insert(a);
    }

    public void Delete(IAppointment data) => Col.Delete(data.ID);

    public void Delete(long id) => Col.Delete(id);

    public OneOf<IAppointment, None> Get(long id)
    {
        var a = Col.Include(x => x.User).FindOne(x => x.ID == id);
        if (a == null)
            return new None();

        return a;
    }

    public IEnumerable<IAppointment> GetAll() => Col.Include(x => x.User).FindAll();

    public long GetCount() => Col.LongCount();

    public long GetMaxID() => Col.Max();

    public long GetMinID() => Col.Min();

    public IEnumerable<IAppointment> GetRange(long offset, int amount, string orderField, bool orderAsc)
    {
        if (orderField == "ID")
            orderField = "_id";

        return Col.Include(x => x.User).Query().OrderBy(orderField, orderAsc ? 1 : 0)
            .Skip((int)offset).Limit(amount).ToEnumerable();
    }

    public IAppointment New(long id, IUser user, string street, string houseNbr, string additionalAddress,
        string postalCode, string city, DateTimeOffset dateTimeCreated, DateTimeOffset dateTimeStart,
        DateTimeOffset dateTimeEnd, string name, string description, bool attendance, bool cancelled)
    {
        return new Appointment(id, user, street, houseNbr, additionalAddress, postalCode, city, dateTimeCreated,
            dateTimeStart, dateTimeEnd, name, description, attendance, cancelled);
    }

    public void Update(IAppointment data)
    {
        if (data is not Appointment a)
            throw new UnsupportedDatabaseException();

        Col.Update(a);
    }
}