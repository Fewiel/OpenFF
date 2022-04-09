namespace OpenFF.DataAccessLayer.Exceptions;

public class UnsupportedDatabaseException : Exception
{
    public UnsupportedDatabaseException()
        : base() { }
    public UnsupportedDatabaseException(string? message)
        : base(message) { }
    public UnsupportedDatabaseException(string? message, Exception? innerException)
        : base(message, innerException) { }
}