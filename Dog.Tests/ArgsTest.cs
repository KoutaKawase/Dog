using System;
using System.Collections.Generic;
using NUnit.Framework;
using Dog;

namespace Dog.Tests
{
    public class ArgsTest
    {
        [Test]
        public void オプションとそれ以外を渡したら２つをタプルで返す()
        {
            var args = new Args(new List<String>(new[] { "-A", "-B", "hoge.cs", "-C", "fuga" }));
            (List<String> options, List<String> files) = args.Separate();

            Assert.AreEqual(new List<String>(new[] { "A", "B", "C" }), options);
            Assert.AreEqual(new List<String>(new[] { "hoge.cs", "fuga" }), files);
        }

        public void オプションが指定した形式以外ならはじかれているか()
        {
            var args = new Args(new List<String>(new[] { "--A", "-2", "-hoge", "-c" }));
            (var options, _) = args.Separate();

            Assert.AreEqual(new List<String>(new[] { "c" }), options);
        }
    }
}
