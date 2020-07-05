using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using Dog;

namespace Dog.Tests
{
    public class FilesTest
    {
        private static readonly String _testDir = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin"));
        private static readonly String _fixturesPath = Path.Combine(_testDir, "fixtures");

        [Test]
        public void 存在しないファイルがあればfalseを返す()
        {
            var hoge = Path.Combine(_fixturesPath, "hoge.cs");
            var fuga = Path.Combine(_fixturesPath, "fuga.json");
            var none = Path.Combine(_fixturesPath, "none.txt");
            var files = new Files(new List<String>(new[] { hoge, fuga, none }));
            var result = files.Exists();

            Assert.False(result);
        }

        [Test]
        public void 全て存在するファイルならtrueを返す()
        {
            var hoge = Path.Combine(_fixturesPath, "hoge.cs");
            var files = new Files(new List<String>(new[] { hoge }));
            var result = files.Exists();

            Assert.True(result);
        }

        [Test]
        public void 渡された名前にディレクトリが存在すれば例外()
        { }
    }
}
