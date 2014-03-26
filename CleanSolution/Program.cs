using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanSolution
{
    class Program
    {
        private static readonly string[] buildFolderNames = new[] {"bin", "obj"};
        static void Main(string[] args)
        {
            var folders = Directory.GetDirectories(Directory.GetCurrentDirectory());
            foreach (var folder in folders)
            {
                DeleteBuildFolders(folder);
            }
        }

        private static void DeleteBuildFolders(string folder)
        {
            if (buildFolderNames.Contains(Path.GetFileName(folder) ?? string.Empty,
                StringComparer.InvariantCultureIgnoreCase))
            {
                try
                {
                    Console.WriteLine(folder);
                    Directory.Delete(folder, true);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
            else
            {
                foreach (var subfolder in Directory.GetDirectories(folder))
                {
                    DeleteBuildFolders(subfolder);
                }
            }
        }
    }
}
