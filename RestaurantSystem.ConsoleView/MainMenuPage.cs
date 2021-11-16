using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.ConsoleView
{
    public class MainMenuPage
    {
        private DishesPage _dishesPage;
        private BasketPage _orderPage;

        public MainMenuPage(DishesPage dishesPage, BasketPage orderPage)
        {
            _dishesPage = dishesPage;
            _orderPage = orderPage;
        }

        public void Start()
        {
            bool exitFromApp = false;
            while (!exitFromApp)
            {
                Console.WriteLine(
                    "\n------------------------------------------------------------\n" +
                    "Main menu" +
                    "\n------------------------------------------------------------\n");
                ShowMainMenu();
                Console.Write(">> ");
                string command = Console.ReadLine();
                switch (command)
                {
                    case "1":
                        _dishesPage.Start();
                        break;
                    case "2":
                        _orderPage.Start();
                        break;
                    case "3":
                        exitFromApp = true;
                        break;
                    default:
                        Console.WriteLine("\nwrong command\n");
                        break;
                }
            }
        }

        private void ShowMainMenu()
        {
            Console.WriteLine(
                "1) dishes  \n" +
                "2) basket \n" +
                "3) exit \n"
                );
        }
    }
}
