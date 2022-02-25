using System;

namespace SingletonExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Singleton.getInstance().printCounter();
            Singleton.getInstance().printCounter();
            Singleton.getInstance().printCounter();
            Singleton.getInstance().printCounter();
        }
    }
}