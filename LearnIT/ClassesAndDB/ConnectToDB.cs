using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LearnIT.ClassesAndDB
{
    internal class ConnectToDB
    {
        private static string pathToDB = "";

        private static FileInfo[] files;

        public ConnectToDB()
        {
            files = new DirectoryInfo(Environment.CurrentDirectory).GetFiles();
            for (int i = 0; i < files.Length; i++)
            {
                if (Regex.IsMatch(files[i].Name, ".+\\.mdf$"))
                {
                    pathToDB = files[i].FullName;
                    break;
                }
            }
            ChangePath(Directory.GetCurrentDirectory());
        }

        /*  private static void Main(string[] args)
          {
              files = new DirectoryInfo(Environment.CurrentDirectory).GetFiles();
              for (int i = 0; i < files.Length; i++)
              {
                  if (Regex.IsMatch(files[i].Name, ".+\\.mdf$"))
                  {
                      pathToDB = files[i].FullName;
                      break;
                  }
              }
              ChangePath(Directory.GetCurrentDirectory());
          }*/

        private static void ChangePath(string path)
        {
            FileInfo[] array = new DirectoryInfo(path).GetFiles();
            for (int i = 0; i < array.Length; i++)
            {
                if (Regex.IsMatch(array[i].FullName, "(?>.+\\.config)||(?>.+\\.cs)"))
                {
                    try
                    {
                        string[] array2 = File.ReadAllLines(array[i].FullName);
                        for (int j = 0; j < array2.Length; j++)
                        {
                            if (Regex.IsMatch(array2[j], "AttachDbFilename=.+\\.mdf"))
                            {
                                array2[j] = Regex.Replace(array2[j], "AttachDbFilename=.+\\.mdf", "AttachDbFilename=" + pathToDB);
                                File.WriteAllLines(array[i].FullName, array2);
                                return;
                            }
                        }
                    }
                    catch
                    {
                    }
                }
            }
            DirectoryInfo[] directories = new DirectoryInfo(path).GetDirectories();
            for (int k = 0; k < directories.Length; k++)
            {
                ChangePath(directories[k].FullName);
            }
        }
    }
}