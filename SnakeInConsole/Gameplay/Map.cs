namespace SnakeInConsole;

public class Map
{
    public int[,] MapArray;

    public Map(int width, int heigth, bool isCustom)
    {
        MapArray = new int[width,heigth];
        if (isCustom)
        {
            
        }
        else
        {
            GenerateDefaultMap();
        }
    }

    void GenerateDefaultMap()
    {
        for (int x = 0; x < MapArray.GetLength(0); x++)
        {
            for (int y = 0; y < MapArray.GetLength(1); y++)
            {
                if (y == 0)
                {
                    MapArray[x, y] = 1;
                }else if (x == 0 || x == MapArray.GetLength(0) - 1)
                {
                    MapArray[x, y] = 1;

                }else if (y == MapArray.GetLength(1) - 1)
                {
                    MapArray[x, y] = 1;
                }
                else
                {
                    MapArray[x, y] = 0;
                }
            }
        }

        for (int i = 0; i < MapArray.GetLength(0); i++)
        {
            for (int j = 0; j < MapArray.GetLength(1); j++)
            {
                Drawer.Draw(MapArray[i,j] == 1 ? "#" : " ", i , j);
            }
        }
    }
}