using Godot;
using System;

public partial class ChangeColorItem : Area2D
{
	[Export(PropertyHint.Enum, "0, 1, 2, 3")]
	public int ColorIndex = 0;
	[Export]
	private Color[] _Colors = { Colors.Red, Colors.Blue, Colors.Yellow, Colors.Green };
	private Sprite2D Sprite;

	public override void _Ready()
	{
		Sprite = GetNode<Sprite2D>("Sprite2D");
		Sprite.Modulate = _Colors[ColorIndex];
	}

	private void OnBodyEntered(Player body)
	{
		body.ChangeColor(_Colors[ColorIndex]);
	}
}




