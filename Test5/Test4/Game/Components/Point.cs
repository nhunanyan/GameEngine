using Test4.Engine.Components;

namespace Test4.Game.Components;

public class Point : Component, ICanvasDrawable
{
    public Transform Transform { get; private set; }
    public bool CollisionDetect { get; set; }
    
    public override void Awake()
    {
        CollisionDetect = false;
        Transform = GameObject.GetComponent<Transform>();
    }

    public char[,] PointPosition()
    {
        char[,] arr = new char[1, 1];
        arr[0, 0] = '*';
        return arr;
    }
    
    public DrawInfo GetDrawInfo()
    {
        var shape = PointPosition();
        return new DrawInfo(Transform.Position, shape);
    }
    
    public override void OnCollisionDetect(ICollider other)
    {
        CollisionDetect = true;
    }
    
    public override void Update()
    {
        
    }
    
    
}