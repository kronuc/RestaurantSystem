using System;
using RestaurantSystem.ConsoleView;

namespace RestaurantSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleClient client = new ConsoleClient();
            client.Start();
        }
    }
}
