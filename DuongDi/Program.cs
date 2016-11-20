using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuongDi
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = NextInt();
            int M = NextInt();
            long[,] Matrix = new long[N + 1, M + 1];
            for (int i = 1; i < N+1; i++)
            {
                if (i==1)
                {
                    for (int j = 1; j < M + 1; j++)
                    {

                        Matrix[1, j] = Matrix[1,j-1] + NextInt();
                    }
                }
                else
                {
                    for (int j = 1; j < M + 1; j++)
                    {

                        Matrix[i, j] = NextInt();
                    }
                }
            }
            for (int i = 1; i < N+1; i++)
            {
                Matrix[i, 1] = Matrix[i - 1, 1] + Matrix[i, 1];
            }
            
            for (int i = 2; i < N + 1; i++)
            {
                for (int j = 2; j < M + 1; j++)
                {
                    Matrix[i, j] = Math.Max(Matrix[i, j - 1], Matrix[i - 1, j]) + Matrix[i, j];
                }
            }
            Console.Write(Matrix[N, M]);
        }
        #region Input wrapper

        static int s_index = 0;
        static string[] s_tokens;

        private static string Next()
        {
            while (s_tokens == null || s_index == s_tokens.Length)
            {
                s_tokens = Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                s_index = 0;
            }
            return s_tokens[s_index++];
        }

        private static int NextInt()
        {
            return Int32.Parse(Next());
        }

        private static long NextLong()
        {
            return Int64.Parse(Next());
        }

        #endregion
    }
}
