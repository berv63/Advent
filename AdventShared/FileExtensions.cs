using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AdventShared
{
    public static class FileExtensions
    {
        public static string GetFileLocation(string adventNumber)
        {
            var methodName = GetMethodName();
            var methodTypeIndex = methodName.IndexOf('_');
            var methodType = methodName.Substring(methodTypeIndex + 1, methodName.Length - 1 - methodTypeIndex);

            return $@"Files\{adventNumber}\{methodType}.txt";
        }
        
        public static string GetFileOutputLocation(string adventNumber, string fileName)
        {
            return $@"Files\{adventNumber}\{fileName}.txt";
        }

        public static string GetMethodName()
        {
            var st = new StackTrace();
            var sf = st.GetFrame(2);

            return sf.GetMethod().Name;
        }
        
        public static List<string> ReadFile(string fileLocation)
        {
            var lines = File.ReadAllLines(fileLocation).ToList();
            return lines;
        }
        
        public static void WriteFile(string fileLocation, IEnumerable<string> debug)
        {
            File.WriteAllLines(fileLocation, debug);
        }
        
        public static void AppendFile(string fileLocation, string debug)
        {
            using (var sw = File.AppendText(fileLocation))
            {
                sw.WriteLine(debug);
            }
        }
    }
}