using System.Net.NetworkInformation;

namespace SnakeInConsole;

public class GameManager
{
    public static bool GameOn { get; private set; } = false;
    public static bool GameOver { get; private set; } = false;

    private Player _player;

    private FoodSpawner _foodSpawner;
    
    private bool playerDead = false;
    
    private Map map;

    private TimeSpan _startRoundTime;
    private TimeSpan _endRoundTime;
    
    
    public GameManager()
    {
        GameOver = false;
        GameOn = true;
        map = new Map(20 , 20);
        _foodSpawner = new FoodSpawner();
        _foodSpawner.OnSpawnFood += FoodSpawnerOnOnSpawnFood;
        _player = new Player();
        ShowBestHighscore();
        SpawnPlayer();
        Update();
        _foodSpawner.StartFoodSpawn(map);
    }

    private void ShowBestHighscore()
    {
        HighscoreManager highscoreManager = new HighscoreManager();
        List<Highscore> highscores = highscoreManager.GetAllHighscores();

        if (highscores.Count <= 0)
            return;
        // Select the best highscore
        Highscore bestHighscore = highscores.OrderByDescending(x => x.HighscoreAmout).FirstOrDefault();
        Drawer.DrawHighscore(bestHighscore);
    }
    private void FoodSpawnerOnOnSpawnFood(object? sender, SpawnPickupEventArgs e)
    {
        Drawer.Draw("@", e.Vector2.X, e.Vector2.Y);
    }

    void SpawnPlayer()
    {
        _player.Vector2.X = map.MapArray.GetLength(0) / 2;
        _player.Vector2.Y = map.MapArray.GetLength(1) / 2;
    }

    void Update()
    {
        Task.Run(async () =>
        {
            _startRoundTime = DateTime.Now.TimeOfDay;
            while (!playerDead)
            {
                if (_player.TrailerManager.Trails.Count > 0)
                    Drawer.Draw(" ", _player.TrailerManager.Trails.Last().Vector2.X, _player.TrailerManager.Trails.Last().Vector2.Y);
                
                Drawer.Draw(" ", _player.Vector2.X, _player.Vector2.Y);
                MovePlayer();
                CheckCol();
                CheckFood();
                Drawer.Draw("O", _player.Vector2.X, _player.Vector2.Y);
                if (_player.TrailerManager.Trails.Count > 0)
                    Drawer.Draw("+", _player.TrailerManager.Trails.First().Vector2.X,_player.TrailerManager.Trails.First().Vector2.Y);
                
                await Task.Delay(300);
            }
            GameOver = true;
            _foodSpawner.OnSpawnFood -= FoodSpawnerOnOnSpawnFood;
            _endRoundTime = DateTime.Now.TimeOfDay;
            SaveScore();
            GameOn = false;
        });
    }

    void MovePlayer()
    {
        PlayerController.ChooseDirection(_player.Direction, _player.Vector2.X, _player.Vector2.Y, out int newX, out int newY);
        _player.Vector2.X = newX;
        _player.Vector2.Y = newY;
        _player.TrailerManager.UpdateTrail(_player.Vector2.X,_player.Vector2.Y, _player.Direction);
    }
    
    void CheckCol()
    {
        if (map.MapArray[_player.Vector2.X,_player.Vector2.Y] != ' ')
        {
            playerDead = true;
        }

        _player.TrailerManager.Trails.ForEach(trail =>
        {
            if (trail.Vector2.X == _player.Vector2.X && trail.Vector2.Y == _player.Vector2.Y)
            {
                playerDead = true;
            }
        });
    }

    void CheckFood()
    {
        _foodSpawner.SpawnedFood.ForEach(food =>
        {
            if (food.Vector2.X == _player.Vector2.X && food.Vector2.Y == _player.Vector2.Y && !food.HasEat)
            {
                food.HasEat = true;
                _player.TrailerManager.AddTrail(_player.Vector2.X, _player.Vector2.Y, _player.Direction);
                Drawer.DrawPoint(_player.TrailerManager.Trails.Count);
            }
        });
    }

    void SaveScore()
    {
        Drawer.NewHighscore(_player.TrailerManager.Trails.Count, _endRoundTime.Subtract(_startRoundTime).Seconds, out Highscore highscore);
        HighscoreManager highscoreManager = new HighscoreManager();
        highscoreManager.SaveHighScore(highscore);
    }

    void Cleanup()
    {
        _player = null;
    }
}