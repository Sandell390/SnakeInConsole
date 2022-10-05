﻿namespace SnakeInConsole;

public class Vector2
{
    public int X { get; set; }
    public int Y { get; set; }

    public Vector2()
    {
        X = 0;
        Y = 0;
    }
    
    public Vector2(int x, int y)
    {
        X = x;
        Y = y;
    }
}