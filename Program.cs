using System;
using System.Diagnostics.Metrics;

namespace Exo
{
    public class Program
    {
        static void Main(string[] args)
        {

            PageWriter writer = new PageWriter();
            Console.WriteLine("Welcome");

            Console.WriteLine("1 : Define number of words");
            Console.WriteLine("2 : Define number of char");
            var a = Console.ReadLine();

            switch (a)
            {
                case "1":
                    Console.WriteLine("You choose 1");
                    Console.WriteLine("How many words do you want");
                    var numberOfWords = Convert.ToInt32(Console.ReadLine());
                    writer.WritePageMaxWord(numberOfWords);
                    Console.WriteLine("How many words do you want");
                    break;
                case "2":
                    Console.WriteLine("You choose 2");
                    Console.WriteLine("How many char do you want");
                    var numberOfchars = Convert.ToInt32(Console.ReadLine());
                    writer.WritePageMaxChar(numberOfchars);
                    break;
                default:
                    Console.WriteLine("Don't do that. " + a + " is not a valid option");
                    break;
            }


            Console.WriteLine("Done");
        }
    }
}