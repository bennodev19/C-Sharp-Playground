using System;

namespace SingletonExample
{
    public class Singleton
    {
        private int counter = 0;
        
        private static Singleton instance; // vor Zugriff von außen geschützt und statisch

        // privater Konstruktor mit Zugriffsschutz von außen
        private Singleton()
        {
        } 

        public static Singleton getInstance()
        {
            // öffentliche Methode, Aufruf durch Code
            if (instance == null)
            {
                // nur wenn keine Instanz besteht, dann erstelle eine neue
                instance = new Singleton();
            }

            return instance;
        }

        public void printCounter()
        {
            Console.WriteLine("Hello World: " + ++counter);
        }
    }
}