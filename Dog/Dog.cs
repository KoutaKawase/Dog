using System;
using System.Collections.Generic;

namespace Dog
{
    public class Dog
    {
        private readonly List<String> _args;

        public Dog(List<String> args)
        {
            _args = args;
        }

        public String Run()
        {
            if (_args.Count == 0) return ShowHelp();
            return "Result";
        }

        public static String ShowHelp()
        {
            return "HELP";
        }
    }
}
