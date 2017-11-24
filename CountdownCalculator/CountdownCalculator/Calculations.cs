using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CountdownCalculator
{
    static class Calculations
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static double Evaluate(string expression)
        {
            var loDataTable = new DataTable();
            var loDataColumn = new DataColumn("Eval", typeof(double), expression);
            loDataTable.Columns.Add(loDataColumn);
            loDataTable.Rows.Add(0);
            return (double)(loDataTable.Rows[0]["Eval"]);
        }

        public static int Print<T>(HashSet<string> permsWithoutRep, IEnumerable<IEnumerable<T>> perms, int target)
        {
            int count = 0;
            foreach (var permWithoutRep in permsWithoutRep)
            {
                foreach (var perm in perms)
                {
                    var pwr = permWithoutRep.Split(',').ToList();
                    string equation = "";
                    for (int i = 0; i < pwr.Count; i++)
                    {
                        if (i == pwr.Count - 1)
                        {
                            string sResult = equation + " " + pwr[i];
                            if (Evaluate(sResult) == target)
                            {
                                count++;
                                Console.WriteLine(sResult);
                            }
                        }
                        else
                        {
                            equation = equation + " " + pwr[i] + " " + perm.ToList()[i];
                        }
                    }
                }
            }
            return count;
        }
    }
}
