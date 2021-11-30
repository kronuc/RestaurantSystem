using NSubstitute;
using RestaurantSystem.DataModel;
using RestaurantSystem.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.ConsoleView
{
    public class BasketPage
    {
        #region static

        public static int SessionBasket { get; set; }

        #endregion

        #region fields

        private readonly IBasketService<int> _basketService;
        private readonly IDishService<int> _dishService;
        private readonly IDictionary<string, Dish<int>> _dishesInCurrentSession;
        
        #endregion fields

        #region ctrs

        public BasketPage()
        {
            _basketService = Substitute.For<IBasketService<int>>();
            _dishService = Substitute.For<IDishService<int>>();
            _dishesInCurrentSession = new Dictionary<string, Dish<int>>();
            InitialiseServices();
        }

        public BasketPage(IBasketService<int> basketService, IDishService<int> dishService)
        {
            _basketService = basketService;
            _dishService = dishService;
            _dishesInCurrentSession = new Dictionary<string, Dish<int>>();
        }

        #endregion ctrs

        #region public

        public void Start()
        {
            bool exitFromApp = false;
            while (!exitFromApp)
            {
                if (SessionBasket == null)
                {
                    CreateBasket();
                }
                ShowHeader();
                var command = GetCommand();
                exitFromApp = HandleCommand(command);
            }
        }

        #endregion public

        #region private

        private void CreateBasket()
        {
            Console.WriteLine("type your name");
            var name = GetCommand();
            SessionBasket = _basketService.CreateBasket(name).Id;
            Console.WriteLine("basket created");
        }

        private void InitialiseServices()
        {
            _basketService.CreateBasket(Arg.Any<string>()).Returns(new Basket<int>() { Id = 1, UserName = "some name" });
            _basketService.GetDishesInBasket(Arg.Any<int>()).Returns(
                new List<Dish<int>>(){
                    new Dish<int>() {Id = 1, TypeId = 0, Price = 1, Weight = 2 },
                    new Dish<int>() {Id = 2, TypeId = 0, Price = 1, Weight = 2 },
                    new Dish<int>() {Id = 3, TypeId = 0, Price = 1, Weight = 2 },
                    new Dish<int>() {Id = 4, TypeId = 0, Price = 1, Weight = 2 }
                });
        }

        private string GetCommand()
        {
            Console.Write(">> ");
            string command = Console.ReadLine();
            return command;
        }

        private void ShowHeader()
        {
            Console.WriteLine(
                    "\n------------------------------------------------------------\n" +
                    "Order Page" +
                    "\n------------------------------------------------------------\n");
            ShowMenu();
        }

        private bool HandleCommand(string command)
        {
            bool exitFromApp = false;
            switch (command)
            {
                case "1":
                    ShowDishesInBasket();
                    break;
                case "2":
                    RemooveItemFormBasket();
                    break;
                case "3":
                    MakeOrder();
                    break;
                case "4":
                    exitFromApp = true;
                    break;
                default:
                    Console.WriteLine("\nwrong command\n");
                    break;
            }
            return exitFromApp;
        }

        private void ShowMenu()
        {
            Console.WriteLine(
                "1) show dishes in basket\n" +
                "2) remove item\n" +
                "3) make order\n" +
                "4) exit\n");
        }

        private void MakeOrder()
        {
            Console.WriteLine(
                $"make order\n" +
                $"1)yes\n" +
                $"2)no\n");
            var command = GetCommand();
            if (command == "1")
            {
                _basketService.MakeOrder(SessionBasket);
            }
        }

        private void RemooveItemFormBasket()
        {
            Console.WriteLine("\nWrite dish number");
            var dishNumber = GetCommand();
            if (_dishesInCurrentSession.ContainsKey(dishNumber))
            {
                var dish = _dishesInCurrentSession[dishNumber];
                _basketService.RemoveDishFromBasket( SessionBasket, dish.Id);
            }
        }

        private void ShowDishesInBasket()
        {
            var dishes = _basketService.GetDishesInBasket(SessionBasket);
            _dishesInCurrentSession.Clear();
            var i = 0;
            foreach (var dish in dishes)
            {
                _dishesInCurrentSession.Add((++i).ToString(), dish);
                Console.WriteLine($"{i,5}  {dish.Weight}");
            }
        }

        #endregion private
    }
}
