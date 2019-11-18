using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPLib
{
    public class Vector
    {
        private const double EPS = 0.001;
        private double x;
        private double y;
        private double z;
        public Vector(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /// <summary>
        /// Сложение веторов
        /// </summary>
        /// <param name="vector1"></param>
        /// <param name="vector2"></param>
        /// <returns></returns>
        public static Vector operator +(Vector vector1, Vector vector2)
        {
            return new Vector(vector1.x + vector2.x, vector1.y + vector2.y, vector1.z + vector2.z);
        }

        /// <summary>
        /// Разность векторов
        /// </summary>
        /// <param name="vector1"></param>
        /// <param name="vector2"></param>
        /// <returns></returns>
        public static Vector operator -(Vector vector1, Vector vector2)
        {
            return new Vector(vector1.x - vector2.x, vector1.y - vector2.y, vector1.z - vector2.z);
        }

        /// <summary>
        /// Произведение векторов (скалярное)
        /// </summary>
        /// <param name="vector1"></param>
        /// <param name="vector2"></param>
        /// <returns></returns>
        public static double operator *(Vector vector1, Vector vector2)
        {
            return vector1.x * vector2.x + vector1.y * vector2.y + vector1.z * vector2.z;
        }

        /// <summary>
        /// Произведение векторов (Векторное)
        /// </summary>
        /// <param name="vector1"></param>
        /// <param name="vector2"></param>
        /// <returns></returns>
        public static Vector operator /(Vector vector1, Vector vector2)
        {
            double[] multVec = new double[3];
            multVec[0] = vector1.y * vector2.z - vector1.z * vector2.y;
            multVec[1] = vector1.z * vector2.x - vector1.x * vector2.z;
            multVec[2] = vector1.x * vector2.y - vector1.y * vector2.x;
            return new Vector(multVec[0], multVec[1], multVec[2]);
        }

        public static bool operator ==(Vector vector1, Vector vector2)
        {
            return Math.Abs(vector1.x - vector2.x) < EPS && Math.Abs(vector1.y - vector2.y) < EPS && 
               Math.Abs(vector1.z - vector2.z) < EPS;
        }

        public static bool operator !=(Vector vector1, Vector vector2)
        {
            return !(vector1 == vector2);
        }
    }
}
