namespace SnakeInConsole;

public class Player : ITransform
{
    private PlayerController _playerController;

    public PlayerController.PlayerDirection Direction = PlayerController.PlayerDirection.UP;
    
    public Vector2 Vector2 { get; set; }

    public TrailerManager TrailerManager;

    public Player()
    {
        Vector2 = new Vector2();
        TrailerManager = new TrailerManager();
        _playerController = new PlayerController();
        _playerController.PlayerInputChanged += PlayerControllerOnPlayerInputChanged;
    }

    private void PlayerControllerOnPlayerInputChanged(object? sender, PlayerInputEventArgs e)
    {
        switch (e.Direction)
        {
            case PlayerController.PlayerDirection.UP when Direction == PlayerController.PlayerDirection.DOWN:
            case PlayerController.PlayerDirection.DOWN when Direction == PlayerController.PlayerDirection.UP:
            case PlayerController.PlayerDirection.LEFT when Direction == PlayerController.PlayerDirection.RIGHT:
            case PlayerController.PlayerDirection.RIGHT when Direction == PlayerController.PlayerDirection.LEFT:
                return;
            default:
                Direction = e.Direction;
                break;
        }
    }
}