using System;
namespace Stack
{
    public class IntStack
    {
        private int[] elements;
        private int nextIndex = 0;
        private int size;

        public IntStack(int size) : this(size, new int[0])
        {
            // nothing todo
        }

        public IntStack(int size, int[] initalElements)
        {
            elements = new int[size];

            // Add intial elements
            for (int i = 0; i < initalElements.Length; i++)
            {
                this.push(initalElements[i]);
            }
        }

        public bool push(int value)
        {
            if (elements.Length <= size)
            {
                // Add Element to Stack
                this.elements[this.nextIndex] = value;
                nextIndex++;

                return true;
            }
            return false;
        }

        public int pop()
        {
            if (!this.isEmpty())
            {
                // Pop Element of Stack
                int toReturnValue = elements[nextIndex - 1];
                nextIndex--;

                return toReturnValue;
            }

            throw new ArgumentOutOfRangeException("No Element left");
        }

        public int peek()
        {
            if (!this.isEmpty())
            {
                // Get last Element of index
                return this.elements[nextIndex - 1];
            }

            throw new ArgumentOutOfRangeException("No Element left");
        }

        public bool isEmpty()
        {
            return this.elements.Length <= 0 || this.nextIndex == 0;
        }

        public int[] toArray()
        {
            return this.elements;
        }

        public int count()
        {
            return this.nextIndex;
        }
    }
}