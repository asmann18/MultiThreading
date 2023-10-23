using Practice8.Exceptions;
using Practice8.Utilities;

namespace Practice8.Models;

public class Quiz
{
    static int count = 1;
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public List<Question> Questions { get;  }=new List<Question>();


    public Quiz(string name,List<Question> questions)
    {
        Id= count++;
        Name = name;
        Questions = questions;
        
    }
    public static Quiz InitializeQuiz()
    {
        Console.WriteLine("Enter the quiz name");
        string name=Console.ReadLine().Capitalize();
        if (name.Length < 3)
        {
            throw new InvalidInputException("Name length must be 3");
        }
        Console.WriteLine("How many questions do you want to add?");
        bool isParse = byte.TryParse(Console.ReadLine(), out byte count);
        if (!isParse)
        {
            throw new InvalidInputException();
        }
        List<Question> list = new List<Question>();
        for (int i = 0; i < count; i++)
        {
            list.Add(Question.CreateQuestion());
        }

        Quiz quiz = new Quiz(name,list);
        return quiz;
        
    }


    public static void SolveQuiz(Quiz quiz)
    {
        byte result = 0;
        Console.WriteLine(quiz.Name);
        Console.WriteLine("------------------------------------------------------------------------------");
        foreach (Question question in quiz.Questions)
        {
            Console.WriteLine(question.QuestionText);
            Console.WriteLine();
            for (int i = 0; i < question.Variants.Count; i++)
            {
                Console.WriteLine($"{i+1}. {question.Variants[i]}");

            }
            Console.WriteLine("\n Your answer:");
            restart:
            bool isParse=byte.TryParse(Console.ReadLine(), out byte id);
            if(!isParse || id>4 || id < 0)
            {
                Console.WriteLine("Enter the valid number!");
                goto restart;
            }
            if (id == question.TrueVariantId)
            {
                result++;
            }
        }
        Console.WriteLine($"result: {result}/{quiz.Questions.Count}");
    }
    public override string ToString()
    {
        return $"{Id}---{Name} {Questions.Count} Questions";
    }

}
