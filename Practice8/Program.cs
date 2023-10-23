using Practice8.Exceptions;
using Practice8.Models;

namespace Practice8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Quiz> quizzes = new List<Quiz>();
            restart:

            Console.WriteLine("1.Create new Quiz");
            Console.WriteLine("2.Solve a Quiz");
            Console.WriteLine("3.Show Quizzes");
            Console.WriteLine("0.Exit");
            string result=Console.ReadLine();

            try
            {
                switch (result) {

                    case "1":
                        Console.Clear();
                        AddQuiz(quizzes);
                        break;
                        case "2":
                        Console.Clear();
                        Quiz.SolveQuiz(SelectQuiz(quizzes));
                        break;
                        case "3":
                        Console.Clear();
                        ShowQuizzes(quizzes);
                        break;
                        case "0":
                        Console.Clear();
                        Console.WriteLine("Goodbye");
                        return;
                    default:
                        throw new InvalidInputException();

                
                
                
                }

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }


            goto restart;


        }

        public static void AddQuiz(List<Quiz> quizzes)
        {
            quizzes.Add(Quiz.InitializeQuiz());

        }
        public static void ShowQuizzes(List<Quiz> quizzes)
        {
            foreach (Quiz quiz in quizzes)
            {
                Console.WriteLine(quiz);
            }
        }
        public static Quiz SelectQuiz(List<Quiz> quizes)
        {
            Console.WriteLine("Enter the quiz id");
            ShowQuizzes (quizes);
            bool isParse = int.TryParse(Console.ReadLine(), out int id);
            if (!isParse)
            {
                throw new InvalidInputException();
            }
            var quiz=quizes.FirstOrDefault(x=>x.Id==id);
            if (quiz == null)
            {
                throw new QuizNotFoundException();
            }
            return quiz;
            

        }
    }
}