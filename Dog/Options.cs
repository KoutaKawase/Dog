using System;
using System.Collections.Generic;

namespace Dog
{
    public class Options
    {
        private readonly List<String> _options;
        public List<String> Value { get { return _options; } }
        private static readonly String versionOption = "v";
        private static readonly String numberOption = "n";

        public Options(List<String> options)
        {
            _options = options;
        }

        public bool ContainsVersionOption()
        {
            var containsVersionOption = _options.Contains(versionOption);
            return containsVersionOption;
        }

        public bool ContainsNumberOption()
        {
            var containsNumberOption = _options.Contains(numberOption);
            return containsNumberOption;
        }
    }
}
