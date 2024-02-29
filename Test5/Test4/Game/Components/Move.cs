using Test4.Engine;
using Test4.Engine.Components;

namespace Test4.Game.Components;

public class Move : Component
{
    private Transform _transform;
    public Vector3 _direction = new Vector3(0, 1, 0);
    private Point _point;
    private float _velocity = 0;
    public const float g = 9.8f;
    private float _height = 0; 

    public override void Awake()
    {
        _transform = GameObject.GetComponent<Transform>();
        _point = GameObject.GetComponent<Point>();
        _height = MathF.Sqrt(MathF.Abs(_transform.Position.Y * _transform.Position.Y - 22 * 22)) - 1;
    }

    public override void Update()
    {
        
        if (_point.CollisionDetect)
        {
            _point.CollisionDetect = false;
            _direction *= -1;
            _velocity = MathF.Sqrt(2 * g * _height) - (MathF.Sqrt(2 * g * _height) * 10) / 100 ;
            _height = (_velocity * _velocity) / (2 * g);
        }

        if (_direction.Y < 0 && _transform.Position.Y <= (21 -_height))
        {
            _direction *= -1;
        }
        
        _transform.Position += _direction;
    }
    
}