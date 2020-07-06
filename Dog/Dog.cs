using System;
using System.Collections.Generic;
using System.Text;

namespace Dog
{
    public class Dog
    {
        private readonly Args _args;

        public Dog(Args args)
        {
            _args = args;
        }

        public String Run()
        {
            if (_args.IsEmpty()) return ShowHelp();
            (var options, var files) = _args.Separate();
            if (files.ContainDir()) return ShowContainsDirMessage(files);
            if (!files.Exists()) return "No file";
            return "Result";
        }

        private static String ShowHelp()
        {
            return "HELP";
        }

        private static String ShowContainsDirMessage(Files files)
        {
            var dirs = files.GetOnlyDirectories();
            var sb = new StringBuilder("");
            dirs.ForEach(dir =>
            {
                var message = $"{dir}はディレクトリであり無効な引数です\n";
                sb.Append(message);
            });
            return sb.ToString();
        }
    }
}
