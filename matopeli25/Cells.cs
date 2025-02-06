using Godot;

public partial class Cells : Sprite2D
{
    public Vector2I GridPosition { get; private set; }
    public bool HasObject { get; set; } = false;

    public void Initialize(Vector2I position, Texture2D texture)
    {
        GridPosition = position;
        Texture = texture;
        Position = new Vector2(position.X * 16, position.Y * 16);
    }
}
