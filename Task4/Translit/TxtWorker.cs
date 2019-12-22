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
        
        /// <summary>
        /// Write to TXT file
        /// </summary>
        /// <param name="figures">Figures List</param>
        /// <param name="filePath">File Path</param>
        public static void WriteToFile(string message, string filePath)
        {
            using (StreamWriter SW = new StreamWriter(filePath))
            {
                
                {
                    SW.WriteLine(message);
                }
            }
        }
    }
}
