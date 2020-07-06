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
            var encoding = Encoding.UTF8;
            var sb = new StringBuilder("");

            _files.ForEach(file =>
            {
                try
                {
                    using (var sr = new StreamReader(file))
                    {
                        var line = sr.ReadToEnd();
                        sb.Append(line);
                    }
                }
                catch (IOException e)
                {
                    Console.Error.WriteLine($"{file}: The file could not be read:");
                    Console.Error.WriteLine(e.Message);
                }
                sb.AppendLine();
            });
            return sb.ToString();
        }
    }
}
