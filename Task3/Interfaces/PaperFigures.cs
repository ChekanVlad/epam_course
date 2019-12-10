using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface PaperFigures : IGFigures
    {
        Color GetColor();
        void Paint(Color color);
        bool IsPainted();
    }
}
