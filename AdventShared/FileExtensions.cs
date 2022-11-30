using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventShared
{
    public static class FileExtensions
    {
        public static List<string> ReadFile(string fileLocation)
        {
            var lines = File.ReadAllLines(fileLocation).ToList();
            return lines;
        }
        
        public static void WriteFile(string fileLocation, IEnumerable<string> debug)
        {
            File.WriteAllLines(fileLocation, debug);
        }
    }
}