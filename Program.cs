using System;

namespace Vieyra1802490_ParsingPrototype
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Parser parser = new Parser();
            parser.Start();

            Console.WriteLine("Enter Text");
            parser.inputText = Console.ReadLine();
            Console.WriteLine("Text Entered: ");
            Console.WriteLine(parser.inputText);
            Console.WriteLine("Text parsed: ");
            parser.Parse();
            Console.WriteLine(parser.outputText);


        }
    }
}
