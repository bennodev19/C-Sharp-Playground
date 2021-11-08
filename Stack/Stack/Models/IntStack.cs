using System;

namespace Stack.Models
{
    public class IntStack
    {
        private int[] elements;

        private int nextIndex = 0;
        public int size = 0;

        public IntStack(int size) : this(size, new int[0])
        {
            // nothing todo
        }

        public IntStack(int size, int[] initialElements)
        {
            elements = new int[size];

            // Add initial Elements
            for (int i = 0; i < initialElements.Length; i++)
            {
                this.push(initialElements[i]);
            }
        }

        public bool push(int value)
        {
            if (this.size < this.elements.Length)
            {
                // Add Element to Stack
                this.elements[this.nextIndex] = value;
                this.nextIndex++;
                this.size++;

                return true;
            }
    
            return false;
        }

        public int pop()
        {
            if (!this.isEmpty())
            {
                // Pop Element of Stack
                int toReturnValue = this.elements[this.nextIndex - 1];
                this.elements[this.nextIndex - 1] = 0;
                this.nextIndex--;
                this.size--;

                return toReturnValue;
            }

            throw new Exception("No element left to pop!");
        }

        public int peek()
        {
            if (!this.isEmpty())
            {
                // Get last Element of index
                return this.elements[nextIndex - 1];
            }

            throw new Exception("The Stack is empty!");
        }

        public bool isEmpty()
        {
            return this.size <= 0;
        }

        public int[] toArray()
        {
            return this.elements;
        }
    }
}