using OpenFF.DataAccessLayer.Rank;

namespace OpenFF.DataAccessLayer.Qualification;

public interface IQualificationRepository : IRepositoryBase<IQualification>
{
    IQualification New(long id, string name, bool displayed);
}