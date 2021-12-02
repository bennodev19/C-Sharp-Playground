using System;
using System.Text;

namespace BracketParser
{
    public class BracketParser
    {
        private IntStack stack;
        private string toParseValue;
        private char[,] bracketTupels = new[,] {{'{', '}'}, {'(', ')'}, {'[', ']'}};

        public BracketParser(string toParseValue)
        {
            this.toParseValue = this.stripInvalidChars(toParseValue);
            stack = new IntStack(this.toParseValue.Length / 2);
        }
        
        public bool parse()
        {
            bool valid = false;

            // Check if value is even, because otherwise there would be at least one not closing bracket
            if (this.toParseValue.Length > 0 && this.toParseValue.Length % 2 == 0)
            {
                // Check if first char is a closing bracket ('}', ')', ']') -> would be invalid
                if (this.isOpeningBracket(this.toParseValue[0]))
                {
                    var first = this.toParseValue.Substring(0, (int)(this.toParseValue.Length / 2));
                    var last = this.toParseValue.Substring((int)(this.toParseValue.Length / 2), (int)(this.toParseValue.Length / 2));

                    // Fill Stack with the first half of the 'toParseValue'
                    for (int i = 0; i < first.Length; i++)
                    {
                        stack.push(first[0]);
                    }
                   
                    // Validate 'toParseValue'
                    valid = true;
                    for (int i = 0; i < last.Length; i++)
                    {
                        var poppedValue = stack.pop();
                        Console.WriteLine(i + ") Popped: '" + poppedValue + "', Last: '" + this.getOppositeBracket(last[0]) + "'"); // TODO REMOVE
                        if (poppedValue != this.getOppositeBracket(last[0]))
                        {
                            valid = false;
                        }
                    }
                }
            }

            return valid;
        }

        private bool isOpeningBracket(char value)
        {
            bool validValue = false;
            for (int i = 0; i < bracketTupels.GetLength(0) && !validValue; i++)
            {
                if (value == this.bracketTupels[i, 0])
                {
                    validValue = true;
                }
            }
            
            return validValue;
        }

        private bool isValidBracket(char value)
        {
            bool validValue = false;
            // https://stackoverflow.com/questions/9301109/how-do-you-loop-through-a-multidimensional-array
            for (int i = 0; i < this.bracketTupels.GetLength(0) && !validValue; i++)
            {
                for (int j = 0; j < this.bracketTupels.GetLength(1) && !validValue; j++)
                {
                    if (value == this.bracketTupels[i, j])
                    {
                        validValue = true;
                    } 
                }
            }

            return validValue;
        }
        
        // Strip all chars that are no valid 'bracket' (not in bracketTupels)
        private string stripInvalidChars(string value)
        {
            var builder = new StringBuilder();
            foreach (var letter in value)
            {
                if (isValidBracket(letter))
                {
                    builder.Append(letter);
                }
            }

            return builder.ToString();
        }

        private int getOppositeBracket(int bracket)
        {
            for (int i = 0; i < bracketTupels.GetLength(0); i++)
            {
                if (bracketTupels[i, 0] == bracket)
                {
                    return bracketTupels[i, 1];
                }
                
                if (bracketTupels[i, 1] == bracket)
                {
                    return bracketTupels[i, 0];
                }
            }

            return -1;
        }

        public string getStrippedValue()
        {
            return this.toParseValue;
        }
    }
}