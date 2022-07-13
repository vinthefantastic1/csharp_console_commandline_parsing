using System;
using System.Collections.Generic;
using System.CommandLine;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleReadNumbers
{
    class Program
    {
        static async Task Main(string[] args)
        {

            var beginNumber = new Option<int>
                ("--begin", "Number to begin with. Parsed as an int.");

            var endNumber = new Option<int>
                ("--end", "Number to end with. Parsed as an int.");

            var rootCommand = new RootCommand("Parameter binding example");
            rootCommand.Add(beginNumber);
            rootCommand.Add(endNumber);


            rootCommand.SetHandler(
               async (beginValue, endValue) =>
                {
                    DisplayInfo(beginValue,endValue);
                    Console.WriteLine($"{await PrintAsync(beginValue.ToString(), endValue.ToString())}");
                },
                beginNumber, endNumber);

            await rootCommand.InvokeAsync(args);


            return;

        }

        public static void DisplayInfo(int beginNumber, int endNumber)
        {
            Console.WriteLine($"--begin = {beginNumber}");
            Console.WriteLine($"--end = {endNumber}");
        }

        private static Task<string> PrintAsync(string arg1, string arg2)
        {
            return Task.Run(() => myPRINT(arg1, arg2));

            string myPRINT(string myarg1, string myarg2)
            {
                //return $"{myarg1.CompareTo(myarg2)}";

                if (myarg1.CompareTo( myarg2)>0)
                {
                   return $"{myarg1} > {myarg2}";
                }

                if (myarg1.CompareTo(myarg2) < 0)
                {
                    return $"{myarg1} < {myarg2}";
                }

                return $"values entered were {myarg1} and {myarg2}";
            }
           

        }
        private static Task<int> AdditionAsync(int no1, int no2)
        {
            return Task.Run(() => SUM(no1, no2));
            //Local function 
            int SUM(int x, int y)
            {
                return x + y;
            }
        }

    }
}
