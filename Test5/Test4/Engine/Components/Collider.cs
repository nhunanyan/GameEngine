namespace Test4.Engine.Components;

public interface ICollider:IComponent
{
    bool Intersect(ICollider other);
}
public abstract class Collider : Component,ICollider
{
    public Transform Transform { get; private set; }

    public override void Awake()
    {
        Transform = GameObject.GetComponent<Transform>();
    }

    public override void Update()
    {
        
    }

    public abstract bool Intersect(ICollider other);
}

/*
public class BoxCollider : Collider
{
    private Vector3 CenterPosition => Transform.Position + Transform.Scale * 0.5f;

    public override bool Intersect(ICollider other)
    {
        switch (other)
        {
            case BoxCollider boxCollider:
                var direction = boxCollider.CenterPosition - CenterPosition;
                return direction.X <= (boxCollider.Transform.Scale.X + Transform.Scale.X) * 0.5f &&
                       direction.Y <= (boxCollider.Transform.Scale.Y + Transform.Scale.Y) * 0.5f;
            default:
                throw new ArgumentOutOfRangeException(nameof(other));
        }
    }
}
*/