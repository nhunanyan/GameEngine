namespace Test6.Engine;

using Test6.Engine.Components;

public class GameObject
{
    public string Name { get; set; }
    private readonly List<IComponent> _components = new List<IComponent>();
    public GameObject(string name="GameObject")
    {
        Name = name;
        AddComponent<Transform>();
    }
    public T AddComponent<T>() where T : Component, new()
    {
        T component = new T
        {
            GameObject = this
        };
        component.Awake();
        _components.Add(component);
        return component;
    }

    public T GetComponent<T>() where T : IComponent
    {
        return (T)_components.Find(component => component is T);
    }

    public void Update()
    {
        foreach (var component in _components)
        {
            if (component.IsActive)
            {
                component.Update();
            }
        }
    }

    public void OnCollisionDetect(ICollider other)
    {
        foreach (var component in _components)
        {
            if (component.IsActive)
            {
                component.OnCollisionDetect(other);
            }
        }
    }
    
}