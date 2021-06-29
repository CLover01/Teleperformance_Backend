using System;
using System.Collections.Generic;
using System.Text;

namespace Teleperformance_Backend_Test_NetCore
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Help();

                var key = Console.ReadKey();
                switch (key.KeyChar)
                {
                    case '1':
                        Question1_Restock();
                        break;

                    case '2':
                        Question2_Average();
                        break;

                    case '3':
                        Question3_Reverse();
                        break;

                    default:
                        return;
                }

                Console.WriteLine();
            } while (true);
        }

        private static void Help()
        {
            var sb = new StringBuilder();
            sb.AppendLine("This is an simple app for backend tests of TelePerformance, please type:");
            sb.AppendLine("1 for question 1 (restock).");
            sb.AppendLine("2 for question 2 (average scores).");
            sb.AppendLine("3 for question 3 (reverse string).");
            sb.AppendLine("Other keys for existing.");

            Console.WriteLine(sb.ToString());
        }

        private static void Question1_Restock()
        {
            Console.WriteLine();
            Console.WriteLine("You choice question 1.");
            Console.WriteLine("Please type a list of integers and split with ','. For example: 10, 100, 23, 54");
            List<int> itemCount = new List<int>();
            int target = 0;

            do
            {
                var inputString = Console.ReadLine();
                if (!string.IsNullOrEmpty(inputString))
                {
                    var arr = inputString.Split(',');
                    foreach (var str in arr)
                    {
                        if(int.TryParse(str, out int r))
                        {
                            itemCount.Add(r);
                        }
                        else
                        {
                            Console.WriteLine($"Cannot convert {str} to int. Please type again!");
                            itemCount.Clear();
                            break;
                        }
                    }
                }
            } while (itemCount.Count == 0);

            Console.WriteLine("Please type a positive integer as the target:");
            do
            {
                var inputString = Console.ReadLine();
                if (!string.IsNullOrEmpty(inputString))
                {
                    if (int.TryParse(inputString, out int r) && r > 0)
                    {
                        target = r;
                    }
                    else
                    {
                        Console.WriteLine($"Cannot convert {inputString} as int or it is an negative int. Please type again!");
                    }
                }
            } while (target == 0);

            Question1.Restock(itemCount, target);
        }

        private static void Question2_Average()
        {
            Console.WriteLine();
            Console.WriteLine("You choice question 2.");
            Console.WriteLine("Please type a positive number of student:");
            int studentNum = 0;
            var grades = new Dictionary<string, double[]>();

            do
            {
                var inputString = Console.ReadLine();
                if (!string.IsNullOrEmpty(inputString))
                {
                    if (int.TryParse(inputString, out int r) && r > 0)
                    {
                        studentNum = r;
                    }
                    else
                    {
                        Console.WriteLine($"Cannot convert {inputString} as int or it is an negative interger. Please type again!");
                    }
                }
            } while (studentNum == 0);

            Console.WriteLine("Please type 3 positive scores for each student.");
            for (int i = 0; i < studentNum; i++)
            {
                var name = string.Format(Question2.STUDENTTEMPLATE, i);
                Console.WriteLine($"Type 3 scores for {name}. Split the scores with ','. For example: 99.9, 100, 100.");
                double[] scores = new double[Question2.NUMBEROFSCORES];
                int index = 0;
                do
                {
                    var inputString = Console.ReadLine();
                    if (inputString != null)
                    {
                        var arr = inputString.Split(',');
                        foreach (var str in arr)
                        {
                            if (index == 3) break;

                            if (double.TryParse(str, out double r) && r >= 0.0)
                            {
                                scores[index++] = r;
                            }
                            else
                            {
                                index = 0;
                                Console.WriteLine($"Cannot convert {str} as double or it is an negative number. Please type again!");
                                break;
                            }
                        }
                    }

                    if (index != 3) index = 0;
                } while (index != 3);

                grades.Add(name, scores);
            }

            var q2 = new Question2(grades);
            q2.Print();
        }

        private static void Question3_Reverse()
        {
            Console.WriteLine();
            Console.WriteLine("You choice question 3.");
            Console.WriteLine("Please type a string.");
            string inputString;

            do
            {
                inputString = Console.ReadLine();
                if (inputString == null)
                    Console.WriteLine("Nothing input. Please type again!");
            } while (inputString == null);

            var reverse = Question3.Reverse(inputString.ToCharArray());
            Console.WriteLine("Reverse string is:");
            foreach (var c in reverse)
            {
                Console.Write(c);
            }

            Console.WriteLine();
        }
    }
}
