using System;
using System.Collections.Generic;

namespace BracketParser
{
    class Program
    {
        static void Main(string[] args)
        {
            string toParseValue = "{([helloWorld()])}";
            BracketParser bracketParser = new BracketParser(toParseValue);
            Console.WriteLine("Stripped value: '" + bracketParser.getStrippedValue() + "'");
            Console.WriteLine("Missing bracket count: " + bracketParser.getMissingBracketsCount());
            Console.WriteLine("Is parsed value valid: " + bracketParser.isValid());

            List<BracketError> bracketErrors = bracketParser.getErrors();
            foreach (var error in bracketErrors)
            {
                Console.WriteLine(error.message);
            }
        }
    }
}