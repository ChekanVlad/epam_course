using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsLib
{
    /// <summary>
    /// Exceprtions classes
    /// </summary>
    public class Exceptions
    {
        /// <summary>
        /// Wrong parameters exception
        /// </summary>
        public class InvalidParamException : Exception
        {
            public override string Message => "Неверные параметры для выполнения операции.";
            public InvalidParamException() : base()
            { 
            }
        }

        /// <summary>
        /// Impossible to cut figure exception
        /// </summary>
        public class CuttingException : Exception
        {
            public override string Message => "Невозможно вырезать фигуру.";

            public CuttingException() : base()
            {
            }
        }

        /// <summary>
        ///  Exception when figure is already painted
        /// </summary>
        public class PaintException : Exception
        {
            public override string Message => "Фигура уже покрашена.";

            public PaintException() : base()
            {
            }
        }

        /// <summary>
        /// No place in box exception
        /// </summary>
        public class NoPlaceException : Exception
        {
            public override string Message => "В коробке нет места.";

            public NoPlaceException() : base()
            {
            }
        }

        /// <summary>
        /// Empty box exception
        /// </summary>
        public class EmptyBoxException : Exception
        {
            public override string Message => "Коробка пуста.";

            public EmptyBoxException() : base()
            {
            }
        }

        /// <summary>
        /// Exist figure exceprion
        /// </summary>
        public class ExistFigureException : Exception
        {
            public override string Message => "Данная фигура уже есть в коробке.";

            public ExistFigureException() : base()
            {
            }
        }
    }
}
