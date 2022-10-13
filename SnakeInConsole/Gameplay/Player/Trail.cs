namespace SnakeInConsole;

public class Trail : ITransform
{
    public Vector2 Vector2 { get; set; } = new Vector2();
    public PlayerController.PlayerDirection Direction { get; set; }

    public Trail(int x, int y, PlayerController.PlayerDirection direction)
    {
        Vector2.X = x;
        Vector2.Y = y;
        Direction = direction;
    }

}