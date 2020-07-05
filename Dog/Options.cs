using System;
using System.Collections.Generic;

namespace Dog
{
    public class Options
    {
        private readonly List<String> _options;
        public List<String> Value { get { return _options; } }

        public Options(List<String> options)
        {
            _options = options;
        }
    }
}
