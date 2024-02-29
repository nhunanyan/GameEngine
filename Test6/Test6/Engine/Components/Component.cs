namespace Test6.Engine.Components;

public interface IComponent
{
    bool IsActive { get; }
    void Update();
    void OnCollisionDetect(ICollider other);
}

public abstract class Component : IComponent
{
    public GameObject GameObject { get; internal set; }
    public bool IsActive { get; private set; }

    protected Component()
    {
        IsActive = true;
    }

    public virtual void Awake()
    {
    }

    public void SetActive(bool state)
    {
        IsActive = state;
    }

    public abstract void Update();
    public virtual void OnCollisionDetect(ICollider other)
    {
        
    }
}