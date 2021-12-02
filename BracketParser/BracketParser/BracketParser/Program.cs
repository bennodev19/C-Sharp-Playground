using System;

namespace BracketParser
{
    class Program
    {
        static void Main(string[] args)
        {
            string toParseValue = "{}";
            BracketParser bracketParser = new BracketParser(toParseValue);
            Console.WriteLine("Stripped value: '" + bracketParser.getStrippedValue() + "'");
            
            Console.WriteLine("Is parsed value valid: " + bracketParser.parse());
        }
    }
}