using Test4.Engine.Components;
using Vector3 = Test4.Engine.Vector3;

namespace Test4.Game.Components;


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