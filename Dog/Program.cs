using System;
using System.Collections.Generic;

namespace Dog
{
    class Program
    {
        static void Main(string[] args)
        {
            var dog = new Dog(new List<String>(args));
            var result = dog.Run();
            Console.WriteLine(result);
        }
    }
}
