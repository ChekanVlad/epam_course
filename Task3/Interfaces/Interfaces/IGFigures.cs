using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    /// <summary>
    /// Colors
    /// </summary>
    public enum Color
    {
        None,
        White,
        Black,
        Red,
        Green,
        Blue,
    }

    /// <summary>
    /// Geometrical Figures Interface
    /// </summary>
    public interface IGFigures
    {
        double Square { get; }
        double Perimetr { get; }
        string GetFigureType();
        string GetMaterial();
    }
}
