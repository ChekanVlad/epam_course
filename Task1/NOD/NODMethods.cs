using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOD
{
    public class NODMethods
    {
        public static int Euclidean(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

            while ((a != 0) && (b != 0))
            {
                if (a > b)
                    a -= b;
                else
                    b -= a;
            }

            return Math.Max(a, b);
        }
    }
}
