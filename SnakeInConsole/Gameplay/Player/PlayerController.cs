namespace SnakeInConsole;

public class PlayerController
{
    public const ConsoleKey UP = ConsoleKey.W;
    public const ConsoleKey DOWN = ConsoleKey.S;
    public const ConsoleKey LEFT = ConsoleKey.A;
    public const ConsoleKey RIGHT = ConsoleKey.D;

    private CancellationToken _cancellationToken;

    public enum PlayerDirection
    {
        UP = 0,
        DOWN = 1,
        LEFT = 2,
        RIGHT = 3
    }
    
    public event EventHandler<PlayerInputEventArgs> PlayerInputChanged;

    public PlayerController()
    {
        CheckPlayerInput();
    }

    void CheckPlayerInput()
    {
        Task.Run(() =>
        {
            while (!GameManager.GameOver)
            {
                switch (Console.ReadKey(false).Key)
                {
                    case UP:
                        PlayerInputChanged?.Invoke(this, new PlayerInputEventArgs(PlayerDirection.UP));
                        break;
                    case DOWN:
                        PlayerInputChanged?.Invoke(this, new PlayerInputEventArgs(PlayerDirection.DOWN));
                        break;
                    case LEFT:
                        PlayerInputChanged?.Invoke(this, new PlayerInputEventArgs(PlayerDirection.LEFT));
                        break;
                    case RIGHT:
                        PlayerInputChanged?.Invoke(this, new PlayerInputEventArgs(PlayerDirection.RIGHT));
                        break;
                }
            }

            Task.Delay(5000);
            
        }, _cancellationToken);
        
    }
    
    public static void ChooseDirection(PlayerController.PlayerDirection direction, int xIn, int yIn, out int xOut, out int yOut)
    {
        xOut = xIn;
        yOut = yIn;
        switch (direction)
        {
            case PlayerDirection.UP:
                yOut -= 1;
                break;
            case PlayerDirection.DOWN:
                yOut += 1;
                break;
            case PlayerDirection.LEFT:
                xOut -= 1;
                break;
            case PlayerDirection.RIGHT:
                xOut += 1;
                break;
        }
    }

}