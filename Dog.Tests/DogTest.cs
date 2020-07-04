using NUnit.Framework;
using Dog;

namespace Dog.Tests
{
    public class DogTest
    {
        private Dog _dog;
        [SetUp]
        public void Setup()
        {
            _dog = new Dog();
        }

        [Test]
        public void Test1()
        {
            Assert.AreEqual("RUN", _dog.Run());
        }
    }
}