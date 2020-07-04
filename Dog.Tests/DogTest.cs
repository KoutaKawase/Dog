using System;
using System.Collections.Generic;
using NUnit.Framework;
using Dog;

namespace Dog.Tests
{
    public class DogTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void コマンドライン引数がなければヘルプを表示()
        {
            var args = new Args(new List<String>(new String[] { }));
            var dog = new Dog(args);
            var result = dog.Run();

            Assert.AreEqual("HELP", result);
        }

        [Test]
        public void コマンドライン引数があればヘルプが表示されない()
        {
            var args = new Args(new List<String>(new String[] { "hoge" }));
            var dog = new Dog(args);
            var result = dog.Run();

            Assert.AreNotEqual("HELP", result);
        }

        public void コマンドライン引数を渡したらファイル名が返ってくる()
        {
        }
    }
}