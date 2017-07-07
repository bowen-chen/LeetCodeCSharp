using System;
using System.Collections.Generic;

namespace Demo
{
    public static class Utility
    {
        public static void Print<T>(this T[,] m)
        {
            for(int i = 0; i<m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    Console.Write("{0}, ", m[i,j]);
                }

                Console.WriteLine();
            }
        }

        public static void Print<T>(this IEnumerable<T> m)
        {
            foreach (T i in m)
            {
                Console.Write("{0}, ", i);
            }

            Console.WriteLine();
        }
    }
}
