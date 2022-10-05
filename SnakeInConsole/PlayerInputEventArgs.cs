namespace SnakeInConsole;

public class PlayerInputEventArgs : EventArgs
{
    public PlayerController.PlayerDirection Direction { get; }

    public PlayerInputEventArgs(PlayerController.PlayerDirection direction)
    {
        Direction = direction;
    }
}