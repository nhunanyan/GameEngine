using Test6.Engine;
using Test6.Engine.Components;

namespace Test6.Game.Components;

public class Move : Component
{
    private Transform _transform;
    private Ball _ball;
    public Vector3 _direction = new Vector3(0, 1, 0);
    private float _velocity = 20;
    private float _xVelocity;
    private float _yVelocity;
    private float _angle = 0.785398f;
    public const float g = 9.8f;
    private float _height = 0;
    private float _length = 0;
    private float _deltaTime = 0.1f;
    private float _time;
    
    public override void Awake()
    {
        _transform = GameObject.GetComponent<Transform>();
        _ball = GameObject.GetComponent<Ball>();
        var num = MathF.Sin(_angle);
        _height = (_velocity * _velocity * MathF.Sin(_angle) * MathF.Sin(_angle)) / (2 * g);
        _length = _velocity * _velocity * MathF.Sin(2 * _angle) / g;
        _time = 0;
        _xVelocity = _velocity * MathF.Cos(_angle);
        _yVelocity = _velocity * MathF.Sin(_angle);
    }
    
    public override void Update()
    {
        if (_xVelocity * _time <= _length || _yVelocity * _time - (g * _time * _time) / 2 > 0)
        {
            _transform.Position = new Vector3(_xVelocity * _time, 24 - _yVelocity * _time + (g * _time * _time) / 2);
        }
        
        _time += _deltaTime;
    }
}