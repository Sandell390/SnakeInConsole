namespace SnakeInConsole;

public static class Drawer
{
    private static int xOffset = 2;
    private static int yOffset = 2;
    private static int Padding = 2;
    
    public static void Draw(string content, int x, int y)
    {
        Console.SetCursorPosition((xOffset + x) * Padding, yOffset + y);
        Console.Write(content);
        Console.SetCursorPosition(0,0);
    }
}