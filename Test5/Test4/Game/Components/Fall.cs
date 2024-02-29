using Test4.Engine;
using Test4.Engine.Components;

namespace Test4.Game.Components;

public class Fall : Component
{
    private Transform _transform;
    private Bounds _bounds;
    private float _velocity = 0;
    public const float g = 9.8f;
    private float _timeStep = 0.1f;
    public override void Awake()
    {
        _transform = GameObject.GetComponent<Transform>();
    }

    public override void Update()
    {
        float acceleration = -g; 
        _velocity += acceleration * _timeStep; // v = u + at
        _transform.Position.Y += _velocity * _timeStep; // s = ut + 0.5 * at^2 
    }

    public void SetBounds(Bounds bounds)
    {
        _bounds = bounds;
    }
}