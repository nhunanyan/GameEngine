namespace Test6.Engine.Components;

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
