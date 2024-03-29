﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOD
{
    /// <summary>
    /// Methods for NOD
    /// </summary>
    public class NODMethods
    {
        /// <summary>
        /// Euclidean
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
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

            time += (DateTime.Now - t).TotalSeconds;
            return Math.Max(a, b);
        }

        /// <summary>
        /// Euclidean (3 el)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static int Euclidean(int a, int b, int c, ref double time)
        {
            DateTime t = DateTime.Now;
            c = Math.Abs(c);
            time += (DateTime.Now - t).TotalSeconds;
            return Euclidean(c, Euclidean(a, b, ref time), ref time);
        }

        /// <summary>
        /// Euclidean (4 el)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public static int Euclidean(int a, int b, int c, int d, ref double time)
        {
            DateTime t = DateTime.Now;
            d = Math.Abs(d);
            time += (DateTime.Now - t).TotalSeconds;
            return Euclidean(d, Euclidean(a, b, c, ref time), ref time);
        }

        /// <summary>
        /// Euclidean (5 el)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <param name="e"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public static int Euclidean(int a, int b, int c, int d, int e, ref double time)
        {
            DateTime t = DateTime.Now;
            e = Math.Abs(e);
            time += (DateTime.Now - t).TotalSeconds;
            return Euclidean(e, Euclidean(a, b, c, d, ref time), ref time);
        }
        /// <summary>
        /// Stein
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int Stein(int a, int b, ref double time)
        {
            DateTime t = DateTime.Now;
            if (a == 0)
            {
                time += (DateTime.Now - t).TotalSeconds;
                return b;
            }
            if (b == 0)
            {
                time += (DateTime.Now - t).TotalSeconds;
                return a;
            }                                        
            if (a == b)
            {
                time += (DateTime.Now - t).TotalSeconds;
                return a;
            }            
            if (a == 1 || b == 1)
            {
                time += (DateTime.Now - t).TotalSeconds;
                return 1;
            }                                         
            if ((a & 1) == 0)
            {
                time += (DateTime.Now - t).TotalSeconds;
                return ((b & 1) == 0) ? Stein(a >> 1, b >> 1, ref time) << 1 : Stein(a >> 1, b, ref time);
            }                            
            else
            {
                time += (DateTime.Now - t).TotalSeconds;
                return ((b & 1) == 0) ? Stein(a, b >> 1, ref time) : Stein(b, a > b ? a - b : b - a, ref time);
            }       
        }

        /// <summary>
        /// Get data for gist
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public static double[] gistData(int a, int b, int c, int d, int e)
        {
            double[] timesData = new double[5];
            //
            double time = 0;
            int nodE2 = Euclidean(a, b, ref time);
            timesData[0] = time;
            //
            time = 0;
            int nodE3 = Euclidean(a, b, c, ref time);
            timesData[1] = time;
            //
            time = 0;
            int nodE4 = Euclidean(a, b, c, d, ref time);
            timesData[2] = time;
            //
            time = 0;
            int nodE5 = Euclidean(a, b, c, d, e, ref time);
            timesData[3] = time;
            //
            time = 0;
            int nodS = Stein(a,b, ref time);
            timesData[4] = time;
            return timesData;
        }
    }
}
