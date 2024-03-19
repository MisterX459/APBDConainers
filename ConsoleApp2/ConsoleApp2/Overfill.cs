namespace ConsoleApp2;

public class Overfill : Exception
{
    public Overfill()
    {
    }

    public Overfill(string? message) : base(message)
    {
    }

    public Overfill(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}