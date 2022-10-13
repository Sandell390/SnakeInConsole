namespace SnakeInConsole;

public class HighscoreManager
{
    private FileManager _fileManager = new FileManager();
    
    public HighscoreManager()
    {
        
    }

    public List<Highscore> GetAllHighscores()
    {
        return _fileManager.GetAllHighScoreFile();
    }


    public void SaveHighScore(Highscore highscore)
    {
        _fileManager.SaveHighcoreToFile(highscore);
    }
}