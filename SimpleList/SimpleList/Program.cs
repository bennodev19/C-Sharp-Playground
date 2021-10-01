using System;

namespace SimpleList
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isActive = true;
            while (isActive)
            {
                // Draw Menu
                int selectedMenuPoint = Program.drawMenu();

                // Create List
                List list = new List();

                switch (selectedMenuPoint)
                {
                    case 1:
                        Program.drawList(list);
                        break;
                    case 2:
                        Program.drawAddEnd(ref list);
                        break;
                    case 3:
                        Program.drawAddBeforeElement(ref list);
                        break;
                    case 4:
                        // list.deleteElement(new Pupil()); // TODO
                        break;
                    case 5:
                        clearConsole();
                        list.deleteList();
                        break;
                    case 6:
                        // TODO
                        break;
                    case 7:
                        // TODO
                        break;
                    case 8:
                        // TODO
                        break;
                    case 9:
                        // TODO
                        break;
                    case 0:
                        isActive = false;
                        break;

                    default:
                        Console.WriteLine("Invalid menu point selected!");
                        break;
                }
            
            }
        }

        static int drawMenu()
        {
            clearConsole();

            // Draw
            Console.WriteLine(
                "===================================================\n" +
                "Auswahlmenue Verkettete Liste\n" +
                "===================================================\n" +
                "1 = Datensaetze ansehen\n" +
                "2 = Neuen Datensatz am Ende anfuegen\n" +
                "3 = Neuen Datensatz vor Element Nr. ... einfuegen\n" +
                "4 = Datensatz loeschen\n" +
                "5 = Komplette Liste loeschen\n" +
                "6 = Liste nach Namen sortieren\n" +
                "7 = Liste in Datei speichern\n" +
                "8 = Liste aus Datei lesen\n" +
                "9 = Bildschirm loeschen\n" +
                "0 = Ende\n" +
                "---------------------------------------------------\n");
            Console.Write("Auswahl: ");

            // Read Input
            string input = Console.ReadLine();

            // Format Input
            try
            {
                return Int32.Parse(input);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Invalid Input");
            }

            return -1;
        }

        static void drawAddEnd(ref List list)
        {
            clearConsole();

            Console.WriteLine(
           "===================================================\n" +
           "Add End\n" +
           "===================================================\n" +
           "Adds a Pupil to the end of the List.\n\n");

            Pupil toAddPupil = drawPupilInput();
            list.addEnd(toAddPupil);
        }

        static void drawAddBeforeElement(ref List list)
        {
           Console.WriteLine(
           "===================================================\n" +
           "Add Before Element\n" +
           "===================================================\n" +
           "Adds a Pupil at specified index to the List.\n\n");

            list.addBeforeElement(drawIndexInput(), drawPupilInput());
        }

        static Pupil drawPupilInput()
        {
            // Draw
            Console.WriteLine(
                "Pupil Input:\n" +
                "---------------------------------------------------\n");

            // Read Input
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Location: ");
            string location = Console.ReadLine();
            Console.Write("Phone Number: ");
            string phoneNumber = Console.ReadLine();

            return new Pupil(name, location, phoneNumber);
        }

        static int drawIndexInput()
        {
            // Draw
            Console.WriteLine(
                "Index Input:\n" +
                "---------------------------------------------------\n");

            // Read Input
            Console.Write("\nIndex: ");
            string input = Console.ReadLine();


            // Format Input
            try
            {
                return Int32.Parse(input);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Invalid Input");
            }

            return -1;
        }

        static void drawList(List list)
        {
            clearConsole();

            // Draw Header
            Console.WriteLine(
                "===================================================\n" +
                "List:\n" +
                "===================================================\n");

            Pupil[] pupils = list.getList();

            // Draw empty List
            if(pupils.Length <= 0)
            {
                Console.Write("No Element found!\n\n");
            }

            // Draw List
            for(int i = 0; i < pupils.Length; i++)
            {
                Console.Write("(" + (i + 1) + ") " + pupils[i].name + "\n");
            }

            Console.WriteLine(
              "===================================================\n");

            Program.drawPressKeyToGoToMenu();
        }

        static void drawPressKeyToGoToMenu()
        {
            Console.WriteLine("Press any key to go back to menu!");
            Console.ReadLine();
        }

        static void clearConsole()
        {
            Console.Clear();
        }
    }
}
