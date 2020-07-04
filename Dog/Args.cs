using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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

        public (List<String> options, List<String> files) Separate()
        {
            var options = _args.Where(e =>
            {
                return Regex.IsMatch(e, "^-{1}[a-z|A-Z]");
            })
            .Select(e => e.Trim('-'))
            .ToList();

            var files = new List<String>(new[] { "hoge.cs", "fuga" });

            return (options, files);
        }
    }
}
