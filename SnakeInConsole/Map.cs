namespace SnakeInConsole;

public class Map
{
    public char[,] MapArray;

    public Map(int width, int heigth)
    {
        MapArray = new char[width,heigth];
        GenerateMap();
    }

    void GenerateMap()
    {
        for (int x = 0; x < MapArray.GetLength(0); x++)
        {
            for (int y = 0; y < MapArray.GetLength(1); y++)
            {
                if (y == 0)
                {
                    MapArray[x, y] = '#';
                }else if (x == 0 || x == MapArray.GetLength(0) - 1)
                {
                    MapArray[x, y] = '#';

                }else if (y == MapArray.GetLength(1) - 1)
                {
                    MapArray[x, y] = '#';
                }
                else
                {
                    MapArray[x, y] = ' ';
                }
            }
        }

        for (int i = 0; i < MapArray.GetLength(0); i++)
        {
            for (int j = 0; j < MapArray.GetLength(1); j++)
            {
                Drawer.Draw(MapArray[i,j].ToString(), i , j);
            }
        }
    }
}