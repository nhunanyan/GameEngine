using Test4.Engine;
using Test4.Engine.Components;

namespace Test4.Game.Components;

public class Move : Component
{
    private Transform _transform;
    public Vector3 _direction = Vector3.Left;
    private Bounds _bounds;

    public override void Awake()
    {
        _transform = GameObject.GetComponent<Transform>();
    }

    public override void Update()
    {
        
        if (!_bounds.Intersect(_transform.Position, _transform.Scale))
        {
            _direction *= -1;
        }
        
        _transform.Position += _direction;
    }

    public void SetBounds(Bounds bounds)
    {
        _bounds = bounds;
    }
}