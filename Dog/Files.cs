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

        public String Read()
        {
            var sb = new StringBuilder("");

            _files.ForEach(file =>
            {
                sb.Append(ReadLine(file));
            });
            return sb.ToString();
        }

        private static String ReadLine(String file)
        {
            var sb = new StringBuilder("");
            try
            {
                using (var sr = new StreamReader(file))
                {
                    while (sr.Peek() > -1)
                    {
                        var line = sr.ReadLine();
                        sb.Append(line);
                        sb.AppendLine();
                    }
                }
            }
            catch (IOException e)
            {
                Console.Error.WriteLine(e.Message);
                Environment.Exit(1);
            }
            catch (UnauthorizedAccessException e)
            {
                Console.Error.WriteLine(e.Message);
                Environment.Exit(126);
            }

            return sb.ToString();
        }
    }
}
