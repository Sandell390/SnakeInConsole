namespace SnakeInConsole;

public class MenuManager
{
    
    
    public MenuManager()
    {
        StartMenu();
    }

    public void StartMenu()
    {
        Console.Clear();
        Console.WriteLine("             =================================");
        Console.WriteLine("             |        O+++++++++++++         |");
        Console.WriteLine("             |      Welcome to the most      |");
        Console.WriteLine("             |                               |");
        Console.WriteLine("             |        Epic Snake game        |");
        Console.WriteLine("             |                               |");
        Console.WriteLine("             |      You have ever seen!      |");
        Console.WriteLine("             |        +++++++++++++O         |");
        Console.WriteLine("             |                               |");
        Console.WriteLine("             | Menu v1             By GommeS |");
        Console.WriteLine("             =================================");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("                   Main menu choices:");
        Console.WriteLine();
        Console.WriteLine("                     [1] Start Game");
        Console.WriteLine();
        Console.WriteLine("                     [2] Coop Game");
        Console.WriteLine();
        Console.WriteLine("                     [3] Map editor");
        Console.WriteLine();
        Console.WriteLine("                     [4] High scores");
        Console.WriteLine();
        Console.WriteLine("                     [5] Exit");
        Console.WriteLine();

        Console.WriteLine();
        Console.WriteLine();
        Console.Write("                   Your choice: ");

    }

    public int UserInput()
    {
        bool isInputInvalid = false;
        int userChoice = 0;
        do
        {
            isInputInvalid = !int.TryParse(Console.ReadLine(), out userChoice);

            if (isInputInvalid)
            {
                StartMenu();
            }
            
        } while (isInputInvalid);

        return userChoice;
    }

    public void HighscoreMenu(List<Highscore> highscores)
    {
        Console.Clear();
        Console.WriteLine("             =================================");
        Console.WriteLine("             |        O+++++++++++++         |");
        Console.WriteLine("             |        Highscore Menu         |");
        Console.WriteLine("             |        +++++++++++++O         |");
        Console.WriteLine("             |                               |");
        Console.WriteLine("             | Menu v1             By GommeS |");
        Console.WriteLine("             =================================");
        
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("                   Highscores:");
        Console.WriteLine();
        for (int i = 0; i < highscores.Count; i++)
        {
            if (i > 9)
                break;

            
            Console.WriteLine("         " + highscores[i].Name + " - " + highscores[i].HighscoreAmout + " points" + " - "+ highscores[i].TimeAlive + " seconds");
            Console.WriteLine();
        }

        Console.WriteLine();
        Console.WriteLine();
        Console.Write("         Press any key to return to the main menu: ");
        Console.ReadKey();
    }
}