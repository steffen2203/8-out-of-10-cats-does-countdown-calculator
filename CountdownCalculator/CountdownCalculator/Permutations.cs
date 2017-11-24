using System;
using System.Collections.Generic;
using System.Linq;

namespace CountdownCalculator
{
    public static class Permutations
    {

        public static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> items, int count)
        {
            foreach (var item in items)
            {
                if (count == 1)
                {
                    yield return new T[] { item };
                }
                else
                {
                    foreach (var result in GetPermutations(items, count - 1))
                    {
                        yield return new T[] { item }.Concat(result);
                    }

                }
            }
        }


        public static HashSet<string> GetPermutationsWithoutRepetitions<T>(T[] n, int r)
        {
            return (Generate(new HashSet<string>(), n, r));
        }

        public static HashSet<string> Generate<T>(HashSet<string> h, T[] n, int r, int k = 0)
        {
            if (k >= n.Length)
            {
                h.Add(string.Join(",", n.Take(r).ToArray()));
            }
            else
            {
                Generate(h, n, r, k + 1);

                for (int i = k + 1; i < n.Length; i++)
                {
                    Swap(ref n[k], ref n[i]);

                    Generate(h, n, r, k + 1);

                    Swap(ref n[k], ref n[i]);
                }
            }

            return (h);
        }

        public static void Swap<T>(ref T item1, ref T item2)
        {
            var temp = item1;
            item1 = item2;
            item2 = temp;
        }
    }
}
