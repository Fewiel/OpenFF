namespace OpenFF.DataAccessLayer.Exceptions;

public class UnconfiguredDatabaseException : Exception
{
    public UnconfiguredDatabaseException() : base() { }
    public UnconfiguredDatabaseException(string? message) : base(message) { }
    public UnconfiguredDatabaseException(string? message, Exception? innerException) : base(message, innerException) { }
}