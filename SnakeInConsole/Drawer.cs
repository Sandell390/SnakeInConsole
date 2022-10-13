using System.Collections.Concurrent;

namespace SnakeInConsole;

public static class Drawer
{
    private static int xOffset = 2;
    private static int yOffset = 4;
    private static int Padding = 2;

    private static BlockingCollection<Tuple<string, int, int>> theardSafeList =
        new BlockingCollection<Tuple<string, int, int>>();

    private static bool isThreadMade = false;

    private static Thread drawThread = new Thread(ThreadDraw);
    
    public static void Draw(string content, int x, int y)
    {
        if (!isThreadMade)
        {
            drawThread.IsBackground = true;
            drawThread.Priority = ThreadPriority.Normal;
            drawThread.Start();
            isThreadMade = true;
        }
        
        theardSafeList.Add(new Tuple<string, int, int>(content, (xOffset + x) * Padding,y + yOffset));
    }

    public static void DrawPoint(int points)
    {
        if (!isThreadMade)
        {
            drawThread.IsBackground = true;
            drawThread.Priority = ThreadPriority.Normal;
            drawThread.Start();
            isThreadMade = true;
        }
        
        theardSafeList.Add(new Tuple<string, int, int>($"You have {points} points",xOffset + Padding,yOffset - 1));

    }

    public static void DrawHighscore(Highscore highscore)
    {
        if (!isThreadMade)
        {
            drawThread.IsBackground = true;
            drawThread.Priority = ThreadPriority.Normal;
            drawThread.Start();
            isThreadMade = true;
        }
        
        theardSafeList.Add(new Tuple<string, int, int>($"Highscore: {highscore.HighscoreAmout} by {highscore.Name}",xOffset + Padding,yOffset - 2));
    }

    private static void ThreadDraw()
    {
        foreach (Tuple<string,int,int> tuple in theardSafeList.GetConsumingEnumerable())
        {
            Console.SetCursorPosition(tuple.Item2, tuple.Item3);
            Console.Write(tuple.Item1);
            Console.SetCursorPosition(0,0);
        }
    }
    
    public static void NewHighscore(int points, int time, out Highscore newHighscore)
    {
        Console.Clear();
        Console.WriteLine("You are dead");
        Console.WriteLine("You got " + points + " points");
        Console.WriteLine("You survived for " + time + " seconds");
        Console.WriteLine();
        Console.WriteLine("Enter your name: ");
        string name = Console.ReadLine();
        newHighscore = new Highscore(points, time, name);
    }
    
}