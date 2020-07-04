using System;
using System.Collections.Generic;

namespace Dog
{
    public class Args
    {
        private readonly List<String> _args;

        public Args(List<String> args)
        {
            _args = args;
        }

        public bool IsEmpty()
        {
            return _args.Count == 0;
        }
    }
}
