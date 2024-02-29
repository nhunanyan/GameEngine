namespace Test6.Engine.Components;

public struct DrawInfo
{
    public Vector3 Position { get; }
    public char[,] shape { get; }

    public DrawInfo(Vector3 position, char[,] shape)
    {
        Position = position;
        this.shape = shape;
    }
}

public interface ICanvasDrawable
{
    DrawInfo GetDrawInfo();
}

public class Canvas : Component
{
    public char[,] Space;
    public readonly int Size = 40;

    private readonly List<ICanvasDrawable> _drawables = new List<ICanvasDrawable>();

    private void DefaultSpace(Vector3 position, Vector3 scale)
    {
        for (int i = (int)position.Y; i < scale.Y + position.Y; ++i)
        {
            for (int j = (int)position.X; j < scale.X + position.X; ++j)
            {
                Space[i, j] = ' ';
            }
        }
    }

    public Canvas()
    {
        DrawEmpty();
    }

    private void DrawEmpty()
    {
        Space = new char[Size, Size];
        for (int i = 0; i < Size; ++i)
        {
            for (int j = 0; j < Size; ++j)
            {
                Space[i, j] = ' ';
            }
        }
    }

    public void Append(ICanvasDrawable drawable)
    {
        _drawables.Add(drawable);
    }

    public void DrawShape(Vector3 position, char[,] shapeArray)
    {
        for (int i = (int)position.Y; i < shapeArray.GetLength(0) + position.Y - 1; ++i)
        {
            for (int j = (int)position.X; j < shapeArray.GetLength(1) + position.X - 1; ++j)
            {
                Space[i, j] = shapeArray[(int)(i - position.Y), (int)(j - position.X)];
            }
        }
    }

    public void Print()
    {
        for (int i = 0; i < Size; ++i)
        {
            for (int j = 0; j < Size; ++j)
            {
                Console.Write(Space[i, j]);
            }

            Console.WriteLine();
        }
    }

    public override void Update()
    {
        Console.Clear();
        //DrawEmpty();
        foreach (ICanvasDrawable drawable in _drawables)
        {
            var info = drawable.GetDrawInfo();
            DrawShape(info.Position, info.shape);
        }

        Print();
    }
}