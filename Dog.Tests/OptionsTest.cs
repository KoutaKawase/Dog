using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using Dog;

namespace Dog.Tests
{
    public class OptionsTest
    {
        [Test]
        public void バージョンオプションvが存在すればtrueを返す()
        {
            var options = new Options(new List<String>(new[] { "v", "n" }));
            var containsVersionOption = options.ContainsVersionOption();

            Assert.True(containsVersionOption);
        }
    }
}
