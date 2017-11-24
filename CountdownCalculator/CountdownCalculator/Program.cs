using System;
using System.Collections.Generic;
using System.Linq;

namespace CountdownCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the six numbers separated by a comma.");
            string[] numbers = Console.ReadLine().Split(',').ToArray();
            Console.WriteLine("Enter the target.");
            int target = int.Parse(Console.ReadLine());


            var list = new List<string> { "+", "-", "*", "/"};
            int count = 0;

            for (int i = numbers.Length; i > 0; i--)
            {
                if (i == 1)
                {
                    var perms = Permutations.GetPermutations(list, i);
                    var permsWithoutRep = Permutations.GetPermutationsWithoutRepetitions(numbers, i);

                    count += Calculations.Print(permsWithoutRep, perms, target);
                }
                else
                {
                    var perms = Permutations.GetPermutations(list, i - 1);
                    var permsWithoutRep = Permutations.GetPermutationsWithoutRepetitions(numbers, i);

                    count += Calculations.Print(permsWithoutRep, perms, target);
                }
                
            }
            Console.WriteLine("There were {0} equations that equals {1}", count, target);
            Console.ReadKey();
        }
    }
}
