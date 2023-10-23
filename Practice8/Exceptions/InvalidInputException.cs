namespace Practice8.Exceptions;

public class InvalidInputException:Exception
{
    public string Message { get; set; }
    public InvalidInputException(string message="Invalid input!"):base(message)
    {
        
    }
}
