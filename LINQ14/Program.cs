using System;
namespace LINQ14.Shared
{
    internal class Program
    {
        private static Random random = new Random();
        public static void Main(String[] args)
        {
            Console.ReadKey();
        }
        public static void Method01()
        {
            var names = new[] { "Ali", "Salem", "Abeer", "Reem", "Jalal" };
            //var output01 = string.Join(',', names);
            //Console.WriteLine(output01);

            var output02 = names.Aggregate((a, b) => $"{a},{b}");
            Console.WriteLine(output02);
        }
        public static void Method02()
        {
            var numbers = new[] { 1, 2, 3, 4, 5 };
            var total = 0;

            total = numbers.Aggregate(0, (a, b) => a + b);
            Console.WriteLine(total);



        }
        public static void Method03()
        {
            var quiz = QuestionBank.All;
            var longerstQuestionTitle = quiz[0];
            Console.WriteLine(longerstQuestionTitle);
            longerstQuestionTitle = quiz.Aggregate(longerstQuestionTitle,
                (longest, next) => longest.Title.Length < next.Title.Length ? next : longest,
                x => x);



            Console.WriteLine(longerstQuestionTitle);


        }
        private static void RunCount()
        {
            var quiz = QuestionBank.GetQuestionRange(Enumerable.Range(1, 200));
            Console.WriteLine($"Total Questions: {quiz.Count()}");
            Console.WriteLine($"Total Questions With One Mark : {quiz.Count(x => x.Marks == 1)}");
            Console.WriteLine($"Total Questions With One Mark : {quiz.Where(x => x.Marks == 1).Count()}");
            Console.WriteLine($"Total Questions With One Mark Using LongCount : {quiz.Where(x => x.Marks == 1).LongCount()}");
        }

        private static void RunMax()
        {
            var quiz = QuestionBank.GetQuestionRange(Enumerable.Range(1, 200));
            var maximumMark = quiz.Max(x => x.Marks);
            //var maximumMark = quiz.Where(x => x.Choices.Count < 3).Max(x => x.Marks);
            Console.WriteLine($"Maximum Mark: {maximumMark}");
        }
        private static void RunMaxBy()
        {
            var quiz = QuestionBank.GetQuestionRange(Enumerable.Range(1, 200));
            var maximumQuestionMark = quiz.MaxBy(x => x.Marks);
            //var maximumMark = quiz.Where(x => x.Choices.Count < 3).Max(x => x.Marks);
            Console.WriteLine($"{maximumQuestionMark}");
        }
        private static void RunMin()
        {
            var quiz = QuestionBank.GetQuestionRange(Enumerable.Range(1, 200));
            var maximumMark = quiz.Min(x => x.Marks);
            //var minimumMark = quiz.Where(x => x.Choices.Count < 3).Min(x => x.Marks);
            Console.WriteLine($"Minimum Mark: {maximumMark}");
        }
        private static void RunMinBy()
        {
            var quiz = QuestionBank.GetQuestionRange(Enumerable.Range(1, 200));
            var minimumQuestionMark = quiz.MinBy(x => x.Marks);
            //var minimumMark = quiz.Where(x => x.Choices.Count < 3).MinBy(x => x.Marks);
            Console.WriteLine($"{minimumQuestionMark}");
        }

        private static void RunSum()
        {
            var quiz = QuestionBank.GetQuestionRange(Enumerable.Range(1, 200));
            var total = quiz.Sum(x => x.Marks);
            Console.WriteLine($"total: {total}");
        }

        private static void RunAvg()
        {
            var quiz = QuestionBank.GetQuestionRange(Enumerable.Range(1, 200));
            var average = quiz.Average(x => x.Marks);
            Console.WriteLine($"average: {average.ToString("#.##")}");
        }

    }
}