using Test4.Game.Components;

namespace Test4.Engine;

public struct Bounds
{
    private readonly Vector3 _center;
    private readonly Vector3 _size;

    public readonly float xMin, xMax;
    public readonly float yMin, yMax;

    public Bounds(Vector3 center, Vector3 size)
    {
        _center = center;
        _size = size;

        xMin = _center.X - _size.X * 0.5f;
        xMax = _center.X + _size.X * 0.5f;

        yMin = _center.Y - _size.Y * 0.5f;
        yMax = _center.Y + _size.Y * 0.5f;
    }

    public bool Intersect(Vector3 point, Vector3 size)
    {
        //return (point.X > xMin && point.X < xMax && point.Y > yMin && point.Y < yMax ||
        //       point.X + size.X > xMin && point.X + size.X < xMax && point.Y + size.Y > yMin && point.Y + size.Y < yMax);
        if (!(point.X > xMin && point.X < xMax && point.Y > yMin && point.Y < yMax))
        {
            return false;
        }
        else if (!(point.X + size.X > xMin && point.X + size.X < xMax && point.Y + size.Y > yMin && point.Y + size.Y < yMax))
        {
            return false;
        }

        return true;
    }
}