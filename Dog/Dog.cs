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
            var message = "";
            dirs.ForEach(dir =>
            {
                var warningMessage = $"{dir}はディレクトリであり無効な引数です\n";
                message += warningMessage;
            });
            return message;
        }
    }
}
