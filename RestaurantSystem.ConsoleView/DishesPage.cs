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
    public class DishesPage
    {
        #region fields

        private DishInformaitonPage _dishInformaitonPage;
        private readonly IDishTypeService<int> _dishTypeService;
        private readonly IDictionary<string, DishType<int>> _dishesInCurrentSession;

        #endregion fields

        #region ctrs

        

        public DishesPage(DishInformaitonPage dishInformaitonPage, IDishTypeService<int> dishTypeService)
        {
            _dishTypeService = dishTypeService;
            _dishInformaitonPage = dishInformaitonPage;
            _dishesInCurrentSession = new Dictionary<string, DishType<int>>();
        }

        #endregion //ctrs

        #region public

        public void Start()
        {
            var exitFromApp = false;
            while (!exitFromApp)
            {
                ShowHeader();
                var command = ReadTheCommand();
                exitFromApp = OperateConmmand(command);
            }
        }

        #endregion //public

        #region private

        private void InitialiseServices()
        {
            _dishTypeService
                .GetAllDishTypes()
                .Returns(
                    new List<DishType<int>>()
                    {
                        new DishType<int>() { Id = 1, Name = "some dish" },
                        new DishType<int>() { Id = 2, Name = "some dish 2" },
                        new DishType<int>() { Id = 3, Name = "some dish 3" }
                    });
            _dishTypeService
                .GetDishTypesByName(Arg.Any<string>())
                .Returns(
                    new List<DishType<int>>()
                    {
                        new DishType<int>() { Id = 1, Name = "some dish" },
                        new DishType<int>() { Id = 2, Name = "some dish 2" },
                        new DishType<int>() { Id = 3, Name = "some dish 3" }
                    });
        }


        public bool OperateConmmand(string command)
        {
            var exitFromApp = false;
            switch (command)
            {
                case "1":
                    ShowAllDishesTypes();
                    break;
                case "2":
                    FindDishesByName();
                    break;
                case "3":
                    FindDishesByPlaceInSequence();
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

        private string ReadTheCommand()
        {

            Console.Write(">> ");
            var command = Console.ReadLine();
            return command;
        }

        private void ShowHeader()
        {
            Console.WriteLine(
                    "\n------------------------------------------------------------\n" +
                    "Dishes" +
                    "\n------------------------------------------------------------\n");
            ShowMenu();
        }

        private void ShowMenu()
        {
            Console.WriteLine("" +
                "1) show list of all dishes\n" +
                "2) find dishes by name\n" +
                "3) show information about dish\n" +
                "4) exit\n");
        }

        private void FindDishesByPlaceInSequence()
        {
            Console.Write("\nWrite number of dish \n>>");
            var dishNum = Console.ReadLine();
            if (_dishesInCurrentSession.ContainsKey(dishNum))
            {
                var dish = _dishesInCurrentSession[dishNum];
                _dishInformaitonPage.DishType = dish;
                _dishInformaitonPage.Start();
            }
        }

        private void FindDishesByName()
        {
            Console.Write("\nWrite name of dish \n>>");
            var dishName = Console.ReadLine();
            var dishes = _dishTypeService.GetDishTypesByName(dishName);
            WriteListOfDishes(dishes);
        }

        private void ShowAllDishesTypes()
        {
            var dishes = _dishTypeService.GetAllDishTypes();
            WriteListOfDishes(dishes);
        }

        private void WriteListOfDishes(IEnumerable<DishType<int>> dishes)
        {
            _dishesInCurrentSession.Clear();
            var i = 0;
            foreach (var dish in dishes)
            {
                _dishesInCurrentSession.Add((++i).ToString(), dish);
                WriteDishType(i.ToString(), dish);
            }
        }

        private void WriteDishType(string num,DishType<int> dish)
        {
            Console.WriteLine($"{num,5}  {dish.Name,30}");
        }

        #endregion //private
    }
}
