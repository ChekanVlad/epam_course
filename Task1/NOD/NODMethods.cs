using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOD
{
    public class NODMethods
    {
        /// <summary>
        /// Алгоритм Евклида
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></paramх
        /// <returns></returns>
        public static int Euclidean(int a, int b, ref double time)
        {
            DateTime t = DateTime.Now;
            a = Math.Abs(a);
            b = Math.Abs(b);

            while ((a != 0) && (b != 0))
            {
                if (a > b)
                    a -= b;
                else
                    b -= a;
            }

            time = (DateTime.Now - t).TotalSeconds;
            return Math.Max(a, b);
        }

        /// <summary>
        /// Алгоритм Евклида (для 3-х)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static int Euclidean(int a, int b, int c, ref double time)
        {
            DateTime t = DateTime.Now;
            c = Math.Abs(c);
            int nod = Euclidean(c, Euclidean(a, b, ref time), ref time);
            time = (DateTime.Now - t).TotalSeconds;
            return nod;
        }

        /// <summary>
        /// Алгоритм Стейна
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int Stein(int a, int b, ref double time)
        {
            DateTime t = DateTime.Now;
            if (a == 0)
            {
                time = (DateTime.Now - t).TotalSeconds;
                return b;
            }
            if (b == 0)
            {
                time = (DateTime.Now - t).TotalSeconds;
                return a;
            }                                        
            if (a == b)
            {
                time = (DateTime.Now - t).TotalSeconds;
                return a;
            }            
            if (a == 1 || b == 1)
            {
                time = (DateTime.Now - t).TotalSeconds;
                return 1;
            }                                         
            if ((a & 1) == 0)
            {
                time = (DateTime.Now - t).TotalSeconds;
                return ((b & 1) == 0) ? Stein(a >> 1, b >> 1, ref time) << 1 : Stein(a >> 1, b, ref time);
            }                            
            else
            {
                time = (DateTime.Now - t).TotalSeconds;
                return ((b & 1) == 0) ? Stein(a, b >> 1, ref time) : Stein(b, a > b ? a - b : b - a, ref time);
            }       
        }
    }
}
