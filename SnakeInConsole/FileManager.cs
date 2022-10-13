using Newtonsoft.Json;

namespace SnakeInConsole;

public class FileManager
{
    public List<Highscore> GetAllHighScoreFile()
    {
        MakeSureFileExists();
        // Get json file
        string json = "";
        // Read json file and if it is empty, return empty list
        try
        {
            json = File.ReadAllText("highscore.json");
        }
        catch (Exception)
        {
            return new List<Highscore>();
        }

        // Deserialize json file
        List<Highscore> highscores = JsonConvert.DeserializeObject<List<Highscore>>(json) ?? new List<Highscore>();
        
        // Return highscores
        return highscores;
    }

    // Save highscore to file async
    public void SaveHighcoreToFile(Highscore highscore)
    {
        MakeSureFileExists();
        // Get all highscores
        List<Highscore> highscores = GetAllHighScoreFile();
        
        // Add new highscore
        highscores.Add(highscore);
        
        // Sort highscores
        highscores = highscores.OrderByDescending(x => x.HighscoreAmout).ToList();
        
        // Serialize highscores
        string json = JsonConvert.SerializeObject(highscores);

        
        // save highscores to file and if it fails, throw exception
        try
        {
            File.WriteAllText("highscore.json", json);
        }
        catch (Exception)
        {
            throw;
        }
    }

    // Make sure the file exists
    public void MakeSureFileExists()
    {
        if (!File.Exists("highscore.json"))
        {
            File.Create("highscore.json");
        }
    }
    
}