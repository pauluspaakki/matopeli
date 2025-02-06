using Godot;
using System.Collections.Generic;

public partial class Grid : Node2D
{
    [Export] public int GridWidth = 15;
    [Export] public int GridHeight = 13;
    [Export] public PackedScene CellScene;

    private List<List<Cells>> _grid = new List<List<Cells>>();

    public override void _Ready()
    {
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        for (int y = 0; y < GridHeight; y++)
        {
            List<Cells> row = new List<Cells>();

            for (int x = 0; x < GridWidth; x++)
            {
                Cells cell = (Cells)CellScene.Instantiate();
                cell.Initialize(new Vector2I(x, y), cell.Texture);
                AddChild(cell);
                row.Add(cell);
            }

            _grid.Add(row);
        }
    }
}
