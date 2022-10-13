namespace SnakeInConsole;

public class TrailerManager
{
    public List<Trail> Trails { get; set; }

    private readonly List<Trail> _oldTrailsPos;

    private int oldPlayerX = -1;
    private int oldPlayerY = -1;

    public TrailerManager()
    {
        Trails = new List<Trail>();
        _oldTrailsPos = new List<Trail>();
    }

    public void AddTrail(int playerX, int playerY, PlayerController.PlayerDirection direction)
    {
        Trails.Add(new Trail(playerX, playerY, direction));
        _oldTrailsPos.Add(new Trail(playerX, playerY, direction));
    }

    public void UpdateTrail(int playerX, int playerY, PlayerController.PlayerDirection direction)
    {
        for (int i = 0; i < Trails.Count; i++)
        {
            _oldTrailsPos[i].Vector2.X = Trails[i].Vector2.X;
            _oldTrailsPos[i].Vector2.Y = Trails[i].Vector2.Y;
            
            if (i == 0)
            {
                Trails[i].Vector2.X = oldPlayerX;
                Trails[i].Vector2.Y = oldPlayerY;
                    
                oldPlayerX = playerX;
                oldPlayerY = playerY;
            }
            else
            {
                Trails[i].Vector2.X = _oldTrailsPos[i - 1].Vector2.X;
                Trails[i].Vector2.Y = _oldTrailsPos[i - 1].Vector2.Y;

            }
        }
    }
}