using NSubstitute;
using RestaurantSystem.DataModel;
using RestaurantSystem.Services.Abstractions;
using System;
using System.Collections;
using System.Collections.Generic;

namespace RestaurantSystem.ConsoleView
{
    public class DishInformaitonPage
    {
        #region fields
        
        private readonly IDishService<int> _dishService;
        private readonly IBasketService<int> _basketService;
        private readonly IDictionary<string, Dish<int>> _dishesInCurrentSession;
        private readonly IIngredientService<int> _ingredientService;

        #endregion fields

        #region ctrs

        public DishInformaitonPage()
        {
            _dishesInCurrentSession = new Dictionary<string, Dish<int>>();
            _ingredientService = Substitute.For<IIngredientService<int>>();
            _basketService = Substitute.For<IBasketService<int>>();
            _dishService = Substitute.For<IDishService<int>>();
            InitialiseServices();
        }

        public DishInformaitonPage(IDishService<int> dishService, IBasketService<int> basketService, IIngredientService<int> ingredientService)
        {
            _dishService = dishService;
            _basketService = basketService;
            _ingredientService = ingredientService;

            _dishesInCurrentSession = new Dictionary<string, Dish<int>>();
        }


        #endregion ctrs

        #region members

        public DishType<int> DishType { get; set; }
        public Basket<int> Basket { get; set; }

        #endregion members

        #region public
        
        public void Start()
        {
            bool exitFromApp = false;
            while (!exitFromApp)
            {
                ShowHeader();
                var command = ReadCommand();
                exitFromApp = HandleCommand(command);
            }
        }

        #endregion public

        #region private
       
        private void InitialiseServices()
        {
            _dishService.FindDishByType(Arg.Any<DishType<int>>()).Returns(
                new List<Dish<int>>(){
                    new Dish<int>() {Id = 1, TypeId = 0, Price = 1, Weight = 2 },
                    new Dish<int>() {Id = 2, TypeId = 0, Price = 1, Weight = 2 },
                    new Dish<int>() {Id = 3, TypeId = 0, Price = 1, Weight = 2 },
                    new Dish<int>() {Id = 4, TypeId = 0, Price = 1, Weight = 2 } 
                });

            _ingredientService.GetAllIngredientInDish(Arg.Any<int>()).Returns(
                new List<Ingredient<int>>()
                {
                    new Ingredient<int>() {Id = 1, Decription = "something", Name = "some", Weight = 15},
                    new Ingredient<int>() {Id = 2, Decription = "something", Name = "some", Weight = 15},
                    new Ingredient<int>() {Id = 3, Decription = "something", Name = "some", Weight = 15},
                    new Ingredient<int>() {Id = 4, Decription = "something", Name = "some", Weight = 15}
                });

            _basketService.CreateBasket(Arg.Any<string>()).Returns(new Basket<int>() { Id = 1, UserName = "some name" });
        }

        private void ShowHeader()
        {
            Console.WriteLine(
                    "\n------------------------------------------------------------\n" +
                    "Dish information page" +
                    "\n------------------------------------------------------------\n");
            ShowMenu();
        }

        private string ReadCommand()
        {
            Console.Write(">> ");
            string command = Console.ReadLine();
            return command;
        }

        private bool HandleCommand(string command)
        {
            bool exitFromApp = false;
            switch (command)
            {
                case "1":
                    ShowAllSises();
                    break;
                case "2":
                    ShowDishIngradients();
                    break;
                case "3":
                    AddDishToBasket();
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
    
        private void ShowDishIngradients()
        {
            Console.WriteLine("\nWrite dish number");
            var dishNumber = ReadCommand();
            if (_dishesInCurrentSession.ContainsKey(dishNumber))
            {
                var dish = _dishesInCurrentSession[dishNumber];
                var ingradients = _ingredientService.GetAllIngredientInDish(dish.Id);
                foreach(var ingradient in ingradients)
                {
                    Console.WriteLine($"{ingradient.Weight,5} {ingradient.Name, 20} {ingradient.Decription, 75}");
                }
            }
        }

        private void ShowMenu()
        {
            Console.WriteLine(
                "1) show all awailable sises\n" +
                "2) show ingradiens of dish\n" +
                "3) add to basket\n" +
                "4) exit\n");
        }

        private void ShowAllSises()
        {
            var dishes = _dishService.FindDishByType(DishType);
            var i = 0;
            foreach(var dish in dishes)
            {
                _dishesInCurrentSession.Add((++i).ToString(), dish);
                Console.WriteLine($"{i,5}  {dish.Weight}");
            }
        }

        private void AddDishToBasket()
        {
            Console.WriteLine("\nWrite dish number");
            var dishNumber = ReadCommand();
            if (_dishesInCurrentSession.ContainsKey(dishNumber))
            {
                var dish = _dishesInCurrentSession[dishNumber];
                if (BasketPage.SessionBasket != null)
                {
                    _basketService.AddDishToBasket(dish, BasketPage.SessionBasket.Id);
                }
                else
                {
                    Console.WriteLine("type your name");
                    var name = ReadCommand();
                    BasketPage.SessionBasket = _basketService.CreateBasket(name);
                    Console.WriteLine("basket created");
                }
            }
            
        }

        #endregion private
    }
}
