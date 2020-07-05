using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

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
            var exists = _files.All(file =>
            {
                return File.Exists(file);
            });
            return exists;
        }
    }
}
