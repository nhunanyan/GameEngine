namespace Test4.Engine;

public struct Vector3
{
    public float X;
    public float Y;
    public float Z;

    public Vector3()
    {
        X = 0;
        Y = 0;
        Z = 0;
    }

    public Vector3(float x, float y)
    {
        X = x;
        Y = y;
    }

    public Vector3(float x, float y, float z) : this(x, y)
    {
        Z = z;
    }

    public static Vector3 Zero = new Vector3(0, 0, 0);
    public static Vector3 One = new Vector3(1, 1, 1);

    /// <summary>
    /// Return value (1,0,0)
    /// </summary>
    public static Vector3 Right = new Vector3(1, 0, 0);
    public static Vector3 Left = new Vector3(-1, 0, 0);

    public static Vector3 operator +(Vector3 left, Vector3 right)
    {
        return new Vector3(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
    }

    public static Vector3 operator -(Vector3 left, Vector3 right)
    {
        return new Vector3(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
    }

    public static Vector3 operator *(Vector3 left, float value)
    {
        return new Vector3(left.X * value, left.Y * value, left.Z * value);
    }

    public static float Distance(Vector3 left, Vector3 right)
    {
        return MathF.Sqrt(MathF.Pow(left.X - right.X, 2)
                          + MathF.Pow(left.Y - right.Y, 2)
                          + MathF.Pow(left.Z - right.Z, 2));
    }
}