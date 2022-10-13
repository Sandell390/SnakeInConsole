namespace SnakeInConsole;

public class HighscoreManager
{
    private FileManager _fileManager = new FileManager();
    
    public HighscoreManager()
    {
        
    }

    public List<Highscore> GetAllHighscores()
    {
        return _fileManager.GetListFromFile<Highscore>("highscore");
    }


    public void SaveHighScore(Highscore highscore)
    {
        _fileManager.SaveHighcoreToFile(highscore, "highscore");
    }
}