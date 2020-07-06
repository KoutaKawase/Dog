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

        public (Options options, Files files) Separate()
        {
            var regex = "^-{1}[a-z|A-Z]$";
            var options = _args.Where(e =>
            {
                //-a -b -C -Dとかだけマッチさせたいので --a や -2は弾く
                return Regex.IsMatch(e, regex);
            })
            .Select(e => e.Trim('-'))
            .ToList();

            var files = _args.Where(e =>
            {
                return !Regex.IsMatch(e, regex);
            }).ToList();

            return (new Options(options), new Files(files));
        }

        public bool ContainsVersionArg()
        {
            return true;
        }
    }
}
