namespace Practice8.Exceptions;

public class QuizNotFoundException:Exception
{
    public string Message { get; set; }
    public QuizNotFoundException(string message = "Quiz not found!") : base(message)
    {

    }
}
