namespace SnakeInConsole;

public class GameManager
{
    public static bool GameOn { get; private set; } = false;
    
    private Player _player;

    private FoodSpawner _foodSpawner;
    
    private bool playerDead = false;
    
    private Map map;

    
    
    public GameManager()
    {
        GameOn = true;
        map = new Map(50 , 50);
        _foodSpawner = new FoodSpawner();
        _foodSpawner.OnSpawnFood += FoodSpawnerOnOnSpawnFood;
        _player = new Player();
        SpawnPlayer();
        Update();
        _foodSpawner.StartFoodSpawn(map);
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
                await Task.Delay(100);
            }

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
            }
        });
    }
}