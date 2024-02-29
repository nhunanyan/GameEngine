namespace Test4.Game.Components;

using Test4.Engine.Components;

public class Square : Component, ICanvasDrawable
{
    public Transform Transform { geta; private set; }
    public override void Awake()
    {
        Transform = GameObject.GetComponent<Transform>();
    }

    private void AddRow(char[,] squareArray, int length, int j)
    {
        for (int i = 0; i < length; ++i)
        {
            squareArray[j, i] = '*';
        }
    }

    private void AddSpaces(char[,] squareArray, int count, int j)
    {
        for (int i = 1; i <= count; i++)
        {
            squareArray[j, i] = ' ';
        }
    }

    public char[,] ConstructArray()
    {
        var squareArray = new char[(int)Transform.Scale.Y, (int)Transform.Scale.X];
        AddRow(squareArray,(int)Transform.Scale.X, 0);

        for (int i = 1; i <= Transform.Scale.Y - 2; i++)
        {
            squareArray[i, 0] = '*';
            AddSpaces(squareArray,(int)Transform.Scale.X - 2, i);
            squareArray[i, (int)Transform.Scale.Y - 1] = '*';
        }

        AddRow(squareArray,(int)Transform.Scale.X,(int)Transform.Scale.Y - 1);
        return squareArray;
    }

    public override void Update()
    {
    }

    public override void OnCollisionDetect(ICollider other)
    {
        var collider = other as Collider;
        Console.WriteLine($"Detected: {collider.GameObject.Name}");
    }

    public DrawInfo GetDrawInfo()
    {
        var shape = ConstructArray();
        return new DrawInfo(Transform.Position, shape);
    }
}