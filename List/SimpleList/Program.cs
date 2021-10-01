using System;

namespace SimpleList
{
    class Program
    {
        public Pupil anchor = null;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        void showList(Pupil anchor)
        {

        }

        Pupil addEnd(ref Pupil anchor)
        {
            Pupil newPupil = new Pupil(); // Allocate Storage

            if (anchor != null)
            {
                Pupil walkPupil = anchor;

                // Find the end of list
                while (walkPupil.next == null)
                {
                    walkPupil = walkPupil.next;
                }

                // Add new Pupil to end of the list
                walkPupil.next = newPupil;
            }
            else
            {
                anchor = newPupil;
            }

            return newPupil;
        }

        Pupil addBeforeElement(ref Pupil anchor, int index)
        {
            return new Pupil();
        }

        void deleteElement(ref Pupil anchor, Pupil toDeletePupil)
        {
            
        }

        void deleteList(ref Pupil anchor)
        {

        }

        Pupil searchByNr(Pupil anchor, int index)
        {
            return new Pupil();
        }
    }
}
