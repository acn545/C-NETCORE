using System;

namespace Human
{
    class Program
    {
        static void Main(string[] args)
        {
            Human Brad = new Human("Brad", 10, 10, 10, 1000);
            Human Bradley = new Human("Bradley");
            Bradley.Attack(Brad);
            Bradley.Attack(Brad);
            Console.WriteLine(Brad.health);

        }
    }
}
