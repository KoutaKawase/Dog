using System;
using System.Collections.Generic;

namespace Dog
{
    class Program
    {
        static void Main(string[] args)
        {
            var argList = new Args(new List<String>(args));
            var dog = new Dog(argList);
            var result = dog.Run();
            Console.WriteLine(result);
        }
    }
}
