using System;
using System.IO;

namespace simulation
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Please enter file name");

            //var fileName = Console.ReadLine();
            // basic_input.txt
            //Console.WriteLine("FileName: " + fileName);

            string startupPath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, "data/basic_input.txt");
            string[] fileContent = System.IO.File.ReadAllLines(startupPath);
            Input input = new Input(fileContent);

            input.parseInput();

        }
    }
}
