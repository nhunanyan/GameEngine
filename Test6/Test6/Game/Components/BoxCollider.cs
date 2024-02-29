namespace Test6.Game.Components;

using Test6.Engine.Components;
using Vector3 = Test6.Engine.Vector3;

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