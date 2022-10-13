namespace SnakeInConsole;

public class SpawnPickupEventArgs : EventArgs
{
    public Vector2 Vector2 { get; set; }

    public SpawnPickupEventArgs(Vector2 vector2)
    {
        Vector2 = vector2;
    }
}