using System;

namespace Stack.Models
{
    public class BracketParser
    {
        private IntStack stack;
        private String toParseValue;
        private char[] validChars = new []{'{', ''}

        public BracketParser(String toParseValue)
        {
            this.toParseValue = toParseValue;
            // TODO strip unwanted chars
            stack = new IntStack(toParseValue.Length);
        }
        
        public parse()
        {
            bool valid = false;

            if (this.toParseValue.Length % 2 == 0)
            {
                if(this.toParseValue[0])
                
            }

        }
    }
}