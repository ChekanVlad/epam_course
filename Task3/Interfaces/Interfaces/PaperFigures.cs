using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    /// <summary>
    /// Paper Figures Interface
    /// </summary>
    public interface PaperFigures : IGFigures
    {
        Color GetColor();
        void Paint(Color color);
        bool IsPainted();
    }
}
