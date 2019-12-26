using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    /// <summary>
    /// Work with TXT files
    /// </summary>
    public class TxtWorker
    {
        private static string log = "...//...//...//log.txt";
        /// <summary>
        /// Write to TXT file
        /// </summary>
        public static void WriteToFile(string message)
        {
            using (StreamWriter SW = new StreamWriter(log, true))
            {
                {
                    SW.WriteLine(message);
                }
            }
        }
    }
}
