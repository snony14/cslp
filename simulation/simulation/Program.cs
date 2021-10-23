using System;

namespace simulation
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Please enter file name");

            var FileName = Console.ReadLine();

            Console.WriteLine("FileName: " + FileName);
        }
    }
}
