using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

namespace Dog
{
    public class Files
    {
        private readonly List<String> _files;
        public List<String> Value { get { return _files; } }

        public Files(List<String> files)
        {
            _files = files;
        }

        //全てのファイル名が実在するものか検査するためのもの
        public bool Exists()
        {
            var exists = _files.All(file => File.Exists(file));
            return exists;
        }

        public bool ContainDir()
        {
            //一つでもディレクトリであるものがあればリジェクトしたい
            var containsDir = _files.Any(file => Directory.Exists(file));
            return containsDir;
        }

        public List<String> GetOnlyDirectories()
        {
            var dirs = _files.Where(file => Directory.Exists(file)).ToList();
            return dirs;
        }

        public List<String> GetOnlyInvalidFiles()
        {
            var invalidFiles = _files.Where(file => !File.Exists(file)).ToList();
            return invalidFiles;
        }

        public String Read(Func<String?, int, String>? optionFunc = null)
        {
            var sb = new StringBuilder("");

            _files.ForEach(file =>
            {
                sb.Append(ReadLines(file, optionFunc));
            });
            return sb.ToString();
        }

        private static String ReadLines(String file, Func<String?, int, String>? func)
        {
            var sb = new StringBuilder("");
            var lineNumber = 1;
            try
            {
                using (var sr = new StreamReader(file))
                {
                    while (sr.Peek() > -1)
                    {
                        var line = sr.ReadLine();
                        if (func != null)
                        {
                            line = func(line, lineNumber);
                            lineNumber += 1;
                        }
                        sb.Append(line);
                        sb.AppendLine();
                    }
                }
            }
            catch (IOException e)
            {
                Exit(e, 1);
            }
            catch (UnauthorizedAccessException e)
            {
                Exit(e, 126);
            }

            return sb.ToString();
        }

        private static void Exit(Exception e, int exitCode)
        {
            Console.Error.WriteLine(e.Message);
            Environment.Exit(exitCode);
        }
    }
}
