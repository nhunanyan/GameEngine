using Test4.Engine.Components;
using Vector3 = Test4.Engine.Vector3;

namespace Test4.Game.Components;

public class BoxCollider : Collider
{
    private Vector3 CenterPosition => Transform.Position + Transform.Scale * 0.5f;

    public override bool Intersect(ICollider other)
    {
        switch (other)
        {
            case CircleCollider circleCollider:
                /*
                var position = Transform.Position;
                return position.Y == circleCollider.Transform.Position.Y;
                */
            default:
                throw new ArgumentOutOfRangeException(nameof(other));
        }
    }
}