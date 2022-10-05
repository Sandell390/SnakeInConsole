namespace SnakeInConsole;

public class TrailerManager
{
    public List<Trail> Trails { get; set; }

    private readonly List<Trail> _oldTrailsPos;

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

    // Trail update before Player Loc updates, kinda wack
    public void UpdateTrail(int playerX, int playerY, PlayerController.PlayerDirection direction)
    {
        for (int i = 0; i < Trails.Count; i++)
        {
            _oldTrailsPos[i].Vector2.X = Trails[i].Vector2.X;
            _oldTrailsPos[i].Vector2.Y = Trails[i].Vector2.Y;
            
            if (i == 0)
            {
                switch (direction)
                {
                    case PlayerController.PlayerDirection.UP:
                        if (Trails[i].Direction == PlayerController.PlayerDirection.LEFT)
                        {
                            Trails[i].Vector2.X -= 1;
                        }else if (Trails[i].Direction == PlayerController.PlayerDirection.RIGHT)
                        {
                            Trails[i].Vector2.X += 1;
                        }
                        else
                        {
                            Trails[i].Vector2.Y = playerY + 1;
                        }
                        break;
                    case PlayerController.PlayerDirection.DOWN:
                        if (Trails[i].Direction == PlayerController.PlayerDirection.LEFT)
                        {
                            Trails[i].Vector2.X -= 1;
                        }else if (Trails[i].Direction == PlayerController.PlayerDirection.RIGHT)
                        {
                            Trails[i].Vector2.X += 1;
                        }
                        else
                        {
                            Trails[i].Vector2.Y = playerY - 1;
                        }
                        break;
                    case PlayerController.PlayerDirection.LEFT:
                        if (Trails[i].Direction == PlayerController.PlayerDirection.UP)
                        {
                            Trails[i].Vector2.Y -= 1;
                        }else if (Trails[i].Direction == PlayerController.PlayerDirection.DOWN)
                        {
                            Trails[i].Vector2.Y += 1;
                        }
                        else
                        {
                            Trails[i].Vector2.X = playerX + 1;
                        }
                        break;
                    case PlayerController.PlayerDirection.RIGHT:
                        if (Trails[i].Direction == PlayerController.PlayerDirection.UP)
                        {
                            Trails[i].Vector2.Y -= 1;
                        }else if (Trails[i].Direction == PlayerController.PlayerDirection.DOWN)
                        {
                            Trails[i].Vector2.Y += 1;
                        }
                        else
                        {
                            Trails[i].Vector2.X = playerX - 1;
                        }
                        break;
                }
                Trails[i].Direction = direction;
            }
            else
            {
                Trails[i].Vector2.X = _oldTrailsPos[i - 1].Vector2.X;
                Trails[i].Vector2.Y = _oldTrailsPos[i - 1].Vector2.Y;

            }
        }
    }
}