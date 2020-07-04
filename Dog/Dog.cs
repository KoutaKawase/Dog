using System;
using System.Collections.Generic;

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
            return "Result";
        }

        public static String ShowHelp()
        {
            return "HELP";
        }
    }
}
