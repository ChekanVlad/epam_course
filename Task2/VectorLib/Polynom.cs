﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPLib
{
    public class Polynom
    {
        private double[] coff;

        public Polynom(double[] coff)
        {
            this.coff = coff;
        }

        /// <summary>
        /// Сложение полиномов
        /// </summary>
        /// <param name="polynom1"></param>
        /// <param name="polynom2"></param>
        /// <returns></returns>
        public static Polynom operator +(Polynom polynom1, Polynom polynom2)
        {
            double[] coff = new double[Math.Max(polynom1.coff.Length, polynom2.coff.Length)];
            for (int i = 0; i < coff.Length; i++)
            {
                double p1, p2;
                p1 = p2 = 0;
                if (i < polynom1.coff.Length)
                {
                    p1 = polynom1.coff[i];
                }
                if (i < polynom2.coff.Length)
                {
                    p2 = polynom2.coff[i];
                }
                coff[i] = p1 + p2;
            }
            return new Polynom(coff);
        }

        /// <summary>
        /// Вчитание полиномов
        /// </summary>
        /// <param name="polynom1"></param>
        /// <param name="polynom2"></param>
        /// <returns></returns>
        public static Polynom operator -(Polynom polynom1, Polynom polynom2)
        {
            double[] coff = new double[Math.Max(polynom1.coff.Length, polynom2.coff.Length)];
            for (int i = 0; i < coff.Length; i++)
            {
                double p1, p2;
                p1 = p2 = 0;
                if (i < polynom1.coff.Length)
                {
                    p1 = polynom1.coff[i];
                }
                if (i < polynom2.coff.Length)
                {
                    p2 = polynom2.coff[i];
                }
                coff[i] = p1 - p2;
            }
            return new Polynom(coff);
        }

        /// <summary>
        /// Умножение полиномов
        /// </summary>
        /// <param name="polynom1"></param>
        /// <param name="polynom2"></param>
        /// <returns></returns>
        public static Polynom operator *(Polynom polynom1, Polynom polynom2)
        {
            double[] coff = new double[polynom1.coff.Length + polynom2.coff.Length];
            for (int i = 0; i < polynom1.coff.Length; i++)
            {
                for (int j = 0; j < polynom2.coff.Length; j++)
                {
                    coff[i + j] += polynom1.coff[i] * polynom2.coff[j];
                }
            }
            return new Polynom(coff);
        }
    }
}
