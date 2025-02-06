using Godot;
using System.Collections.Generic;

public partial class Snake : Node2D
{
    private Vector2I _direction = new Vector2I(1, 0); // Oletus: liikkuu oikealle
    private float _moveInterval = 0.2f; // Kuinka usein mato liikkuu (sekunteina)
    private double _timer = 0;

    public override void _Process(double delta)
    {
        _timer += delta;
        if (_timer >= _moveInterval)
        {
            Move();
            _timer = 0;
        }
    }

    private void Move()
    {
        Position += new Vector2(_direction.X * 16, _direction.Y * 16); // Siirrytään ruudukossa 16px kerrallaan
        UpdateRotation();
    }

    private void UpdateRotation()
    {
        if (_direction == new Vector2I(1, 0)) // Oikealle
            RotationDegrees = 0;
        else if (_direction == new Vector2I(-1, 0)) // Vasemmalle
            RotationDegrees = 180;
        else if (_direction == new Vector2I(0, -1)) // Ylös
            RotationDegrees = -90;
        else if (_direction == new Vector2I(0, 1)) // Alas
            RotationDegrees = 90;
    }

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventKey eventKey && eventKey.Pressed)
        {
            if (Input.IsActionPressed("ui_right") && _direction != new Vector2I(-1, 0))
                _direction = new Vector2I(1, 0);
            else if (Input.IsActionPressed("ui_left") && _direction != new Vector2I(1, 0))
                _direction = new Vector2I(-1, 0);
            else if (Input.IsActionPressed("ui_up") && _direction != new Vector2I(0, 1))
                _direction = new Vector2I(0, -1);
            else if (Input.IsActionPressed("ui_down") && _direction != new Vector2I(0, -1))
                _direction = new Vector2I(0, 1);
        }
    }
}
