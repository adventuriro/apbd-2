namespace Containers;

public class NotExistingProductException : Exception
{
    public NotExistingProductException()
    {
    }

    public NotExistingProductException(string? message) : base(message)
    {
    }

    public NotExistingProductException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}