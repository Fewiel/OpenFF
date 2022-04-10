namespace OpenFF.DataAccessLayer.Qualification;

public interface IQualification
{
    long ID { get; }
    string Name { get; }
    bool Displayed { get; }
}
