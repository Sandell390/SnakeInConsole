using System.Text.Json.Serialization;

namespace SnakeInConsole;

public class Highscore
{
    public int HighscoreAmout { get; private set; }
    public int TimeAlive { get; private set; }
    public string Name { get; private set; }
    
    public Highscore(int highscoreAmout, int timeAlive, string name)
    {
        HighscoreAmout = highscoreAmout;
        TimeAlive = timeAlive;
        Name = name;
    }
}