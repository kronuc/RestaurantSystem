using System;

namespace RestaurantSystem.ConsoleView
{
    public class ConsoleClient
    {
        private MainMenuPage _mainMenuPage;

        public ConsoleClient(MainMenuPage mainMenuPage)
        {
            _mainMenuPage = mainMenuPage;
        }

        public void Start()
        {
            _mainMenuPage.Start();
        }
    }
}
