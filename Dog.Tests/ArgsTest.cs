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
            (Options options, Files files) = args.Separate();

            var expectedOptions = new Options(new List<String>(new[] { "A", "B", "C" }));
            var exptectedFiles = new Files(new List<String>(new[] { "hoge.cs", "fuga" }));

            Assert.AreEqual(expectedOptions.Value, options.Value);
            Assert.AreEqual(exptectedFiles.Value, files.Value);
        }

        [Test]
        public void オプションが指定した形式以外ならはじかれているか()
        {
            var args = new Args(new List<String>(new[] { "--A", "-2", "-hoge", "-c" }));
            (Options options, _) = args.Separate();

            var expectedOptions = new Options(new List<String>(new[] { "c" }));

            Assert.AreEqual(expectedOptions.Value, options.Value);
        }
    }
}
