using Practice8.Exceptions;
using Practice8.Utilities;

namespace Practice8.Models;

public class Question
{
    static int count = 1;
    public int Id { get;  }
    public string QuestionText { get; set; } = null!;
    public int TrueVariantId { get; set; }

    public List<string> Variants { get; } = new List<string>();

    public Question(string text,List<string> variants,int trueVariantId)
    {
        Id = count++;
        QuestionText = text;
        Variants = variants;
        TrueVariantId = trueVariantId;
    }

    public static Question CreateQuestion()
    {
        restart:
        Console.WriteLine("Enter the question text:");
        string text=Console.ReadLine().Capitalize();
        text = text.Capitalize();
        if (text.Length < 3)
        {
            Console.WriteLine("Text length must be 3");
            goto restart;
        }
        List<string> variants= new List<string>();
        for (int i = 1; i <= 4; i++)
        {
            Console.WriteLine("Enter the variant "+i);
            string variant=Console.ReadLine().Capitalize();
            if (text.Length == 0)
            {
                throw new InvalidInputException("Varinat length must be 1");
            }
            variants.Add(variant);
            
        }
        Console.WriteLine();
        Console.WriteLine("Enter correct variant id");
        for (int i = 0; i < 4; i++)
        {

            Console.WriteLine($"{i+1}.{variants[i]}");
        }
        bool isParseVariant=byte.TryParse(Console.ReadLine(), out byte trueVariantId);
        if (!isParseVariant || trueVariantId>4  || trueVariantId<1)
        {
            throw new InvalidInputException("Wrong input!");
        }
        Question question = new Question(text,variants,trueVariantId);
        return question;
    }



}
