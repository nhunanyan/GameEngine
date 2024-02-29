namespace Test6.Game.Components;

using Test6.Engine.Components;
using Vector3 = Test6.Engine.Vector3;

public class CircleCollider : Collider
{
    public override bool Intersect(ICollider other)
    {
        switch (other)
        {
            case BoxCollider boxCollider:
                var position = Transform.Position;
                return position.Y == boxCollider.Transform.Position.Y;
            default:
                throw new ArgumentOutOfRangeException(nameof(other));
        }
    }
}