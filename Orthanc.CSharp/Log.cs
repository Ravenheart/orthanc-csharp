using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orthanc.CSharp
{
    public class Log
    {
        private static object SyncRoot = new object();

        public static void Message(string message)
        {
            lock (Log.SyncRoot)
            {
                try
                {
                    File.WriteAllText("D:\\TEMP\\log.txt", message + Environment.NewLine, Encoding.UTF8);
                }
                catch { }
            }
        }
    }
}
