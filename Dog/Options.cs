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

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var other = (Options)obj;
            return _options == other.Value;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value);
        }
    }
}
