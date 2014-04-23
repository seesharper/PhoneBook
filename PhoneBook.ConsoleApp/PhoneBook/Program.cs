using System;

namespace Hik.PhoneBook
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var phoneBookRunner = new PhoneBookRunner())
            {
                phoneBookRunner.Start();

                Console.WriteLine("Press enter to stop background services...");
                Console.ReadLine();
            }
        }
    }
}
