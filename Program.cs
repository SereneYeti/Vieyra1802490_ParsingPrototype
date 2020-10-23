using System;
using System.Security.Cryptography.X509Certificates;

namespace Vieyra1802490_ParsingPrototype
{
    class Program
    {       
        
        static void Main(string[] args)
        {
            Console.WriteLine("You wakeup in a dark room. In the room there is a dusty table with a lamp on it. What do you do?");
            Parser parser = new Parser();
            parser.Start();
            string inpt = "";

            while(inpt != "QUIT" && inpt != "quit" && inpt != "q")
            {
               
                Console.WriteLine("Enter Text or tpye QUIT to quit");
                inpt = parser.inputText = Console.ReadLine();
                Console.WriteLine("Text Entered: ");
                Console.WriteLine(parser.inputText);
                Console.WriteLine("Text parsed: ");
                parser.Parse();
                Console.WriteLine(parser.outputText);
                
            }
            

            //BucketHash bucketHash = new BucketHash();
            //bucketHash.Insert("chest");
            //bucketHash.Insert("key");
            //bucketHash.Insert("lamp");

            //Console.WriteLine(bucketHash.DisplayItemsInTable()); 


            //Console.WriteLine(hashTable.DisplayItems());

        }
    }
}
