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
        public void 渡された名前にディレクトリが存在すればtrue()
        {
            var dir = _fixturesPath;
            var hoge = Path.Combine(_fixturesPath, "hoge.cs");
            var files = new Files(new List<String>(new[] { dir, hoge }));
            var result = files.ContainDir();

            Assert.True(result);
        }

        [Test]
        public void 渡されたものにディレクトリが含まれなかったらfalse()
        {
            var hoge = Path.Combine(_fixturesPath, "hoge.cs");
            var fuga = Path.Combine(_fixturesPath, "fuga.json");
            var none = Path.Combine(_fixturesPath, "none.none");
            var files = new Files(new List<String>(new[] { fuga, hoge, none }));

            Assert.False(files.ContainDir());
        }

        [Test]
        public void 渡されたものの中からディレクトリだけが抽出されているか()
        {
            var dir = _fixturesPath;
            var dir2 = Path.Combine(_fixturesPath, "emptyDir");
            var hoge = Path.Combine(_fixturesPath, "hoge.cs");
            var files = new Files(new List<String>(new[] { dir, dir2, hoge }));
            var dirs = files.GetOnlyDirectories();

            Assert.AreEqual(new List<String>(new[] { dir, dir2 }), dirs);
        }

        [Test]
        public void 渡されたものにディレクトリがなかったら空のリストを返すか()
        {
            var hoge = Path.Combine(_fixturesPath, "hoge.cs");
            var files = new Files(new List<String>(new[] { hoge }));
            var dirs = files.GetOnlyDirectories();

            Assert.AreEqual(new List<String>(), dirs);
        }

        [Test]
        public void 無効なファイル名のみが抽出されているか()
        {
            var hoge = Path.Combine(_fixturesPath, "hoge.cs");
            var none = Path.Combine(_fixturesPath, "none.none");
            var files = new Files(new List<String>(new[] { hoge, none }));
            var expectedFiles = files.GetOnlyInvalidFiles();

            Assert.AreEqual(new List<String>(new[] { none }), expectedFiles);
        }
    }
}
