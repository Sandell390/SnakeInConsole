namespace SnakeInConsole;

using System.Collections.Generic;
using System.Linq;
using System.Collections.Specialized;

public class FoodSpawner
{
    public List<Food> SpawnedFood = new List<Food>();

    public event EventHandler<SpawnPickupEventArgs> OnSpawnFood;

    private Random _random = new Random();
    
    public void StartFoodSpawn(Map map)
    {
        Task.Run(async () =>
        {
            while (!GameManager.GameOver)
            {
                char spawnChar = ' ';
                int rngX = 0;
                int rngY = 0;
                do
                {
                    rngX = _random.Next(0,map.MapArray.GetLength(0));
                    rngY = _random.Next(0, map.MapArray.GetLength(1));

                    spawnChar = map.MapArray[rngX, rngY];
                } while (spawnChar != ' ');
            
                SpawnedFood.Add(new Food(false, new Vector2(rngX,rngY)));
                OnSpawnFood?.Invoke(this, new SpawnPickupEventArgs(new Vector2(rngX,rngY)));
                await Task.Delay(3000);
            }

        });
    }
}