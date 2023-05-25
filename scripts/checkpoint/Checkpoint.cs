using Godot;
using System;

public partial class Checkpoint : Area2D
{
	[Export]
	public Boolean IsFirst = false;

	public override void _Ready()
	{
		if (IsFirst)
		{
			GetNode<Sprite2D>("Sprite2D").Visible = !IsFirst;
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
