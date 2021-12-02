using System;

namespace BracketParser
{
    public class BracketError
    {
        public string message;

        public BracketError(string message)
        {
            this.message = message;
        }
    }
}