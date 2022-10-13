// See https://aka.ms/new-console-template for more information

using SnakeInConsole;

Console.WriteLine("");
Console.WriteLine("Snake By GommeS");

MenuManager menuManager = new MenuManager();
HighscoreManager highscoreManager = new HighscoreManager();

while (true)
{
    menuManager.StartMenu();
    switch (menuManager.UserInput())
    {
        case 1:
            Console.Clear();
            GameManager game = new GameManager();

            while (GameManager.GameOn)
            {
                // DO nothing
            }
            
            
            
            break;
        case 4:
            menuManager.HighscoreMenu(highscoreManager.GetAllHighscores());
            
            break;
        default:
            menuManager.StartMenu();
            break;
    }

}



