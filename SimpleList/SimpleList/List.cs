using System;
using System.Collections;

namespace SimpleList
{
    class List
    {
        public Pupil anchor = null;

        public Pupil[] getList()
        {
            ArrayList list = new ArrayList();

            // Check whether List exists
            if (this.exists())
            {
                // Map Linked List to Array List
                Pupil walkPupil = this.anchor;
                while (walkPupil.next == null)
                {
                    list.Add(walkPupil);
                    walkPupil = walkPupil.next;
                  
                }
            }

            return (Pupil[]) list.ToArray(typeof(Pupil));
        }

        public void addEnd(Pupil newPupil)
        {
            // TODO REMOVE
            Console.WriteLine("Debug: " + this.exists());
            Console.ReadLine();

            // Check whether List exists
            if (this.exists())
            {
                // Go to the end of the List
                Pupil walkPupil = this.anchor;
                while (walkPupil.next == null)
                {
                    walkPupil = walkPupil.next;
                }

                // Add new Pupil to the end of the List
                walkPupil.next = newPupil;
            }
            else
            {
                this.anchor = newPupil;
            }
        }

        public void addBeforeElement(int index, Pupil newPupil)
        {
            // Check whether List exists
            if (this.exists())
            {
                int currentIndex = 0;

                // Find position of to add Item
                Pupil walkPupil = this.anchor;
                while (walkPupil.next == null)
                {
                    // Add Item inbetween
                    if(currentIndex + 1 == index)
                    {
                        newPupil.next = walkPupil.next;
                        walkPupil.next = newPupil;
                    }
                   
                    walkPupil = walkPupil.next;
                    currentIndex++;
                }

                // Add new Pupil to the end of the List
                walkPupil.next = newPupil;
            }
        }

        public void deleteElement(Pupil toDeletePupil)
        {
            // Check whether List exists
            if (this.exists())
            {
                // Check whether the first Element (anchor) must be deleted
                if (this.anchor == toDeletePupil)
                {
                    this.anchor = anchor.next;
                }
                // Another Element must be deleted
                else
                {
                    // Go through List and remove the to delete Element
                    Pupil walkPupil = this.anchor;
                    while (walkPupil.next != null)
                    {
                        if (walkPupil.next == toDeletePupil)
                        {
                            walkPupil.next = toDeletePupil.next;
                            break;
                        }
                        else
                        {
                            walkPupil = walkPupil.next;
                        }

                    }
                }
            }

            // Forces an immediate garbage collection of all generations.
            GC.Collect();
        }

        public void deleteList()
        {
            this.anchor = null;
        }

        public Pupil searchByNr(int index)
        {
            // Check whether List exists
            if (this.exists())
            {
                int currentIndex = 0;
           
                // Find searched Element
                Pupil walkPupil = this.anchor;
                while (walkPupil.next != null)
                {
                    // Retun if correct index found
                    if(currentIndex == index)
                    {
                        return walkPupil;
                    }

                    walkPupil = walkPupil.next;
                    currentIndex++;
                }
            }
            return null;
        }

        public bool exists()
        {
            return this.anchor != null;
        }
    }
}
