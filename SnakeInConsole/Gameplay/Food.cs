namespace SnakeInConsole;

public class Food : ITransform
{
    public bool HasEat { get; set; }
    public Vector2 Vector2 { get; set; }

    public Food(bool hasEat, Vector2 vector2)
    {
        HasEat = hasEat;
        Vector2 = vector2;
    }
}