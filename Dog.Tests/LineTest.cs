using System;
using NUnit.Framework;
using Dog;

namespace Dog.Tests
{
    public class LineTest
    {
        [Test]
        public void ラインの先頭にスペースと行番号を表示()
        {
            var hoge = "hoge";
            var lineNumber = 1;
            var result = Line.AddLineNumber(hoge, lineNumber);

            Assert.AreEqual("  1 hoge", result);
        }
    }
}
