using Newtonsoft.Json;

namespace SnakeInConsole;

public class FileManager
{
    public List<T> GetListFromFile<T>(string filename)
    {
        MakeSureFileExists(filename);
        // Get json file
        string json = "";
        // Read json file and if it is empty, return empty list
        try
        {
            json = File.ReadAllText($"{filename}.json");
        }
        catch (Exception)
        {
            return new List<T>();
        }

        // Deserialize json file
        List<T> data = JsonConvert.DeserializeObject<List<T>>(json) ?? new List<T>();
        
        // Return highscores
        return data;
    }

    // Save highscore to file async
    public void SaveHighcoreToFile<T>(T data, string filename)
    {
        MakeSureFileExists(filename);
        // Get all highscores
        List<T> datalist  = GetListFromFile<T>(filename);
        
        // Add new highscore
        datalist.Add(data);

        // Serialize highscores
        string json = JsonConvert.SerializeObject(datalist);

        
        // save highscores to file and if it fails, throw exception
        try
        {
            File.WriteAllText($"{filename}.json", json);
        }
        catch (Exception)
        {
            throw;
        }
    }

    // Make sure the file exists
    public void MakeSureFileExists(string filename)
    {
        if (!File.Exists($"{filename}.json"))
        {
            File.Create($"{filename}.json");
        }
    }
    
}