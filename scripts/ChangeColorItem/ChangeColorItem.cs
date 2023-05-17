using Godot;
using System;

public partial class ChangeColorItem : Area2D
{
	[Export(PropertyHint.Enum, "#e31009, #0000ff, ##ffff00, #00ff00")]
	private string color = ColorStates.RED;
	private Sprite2D Sprite;

	public override void _Ready()
	{
        AreaEntered += OAreaEntered;
		Sprite = GetNode<Sprite2D>("Sprite2D");
		Sprite.Modulate = Color.FromHtml(color);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	private void OAreaEntered(Area2D area)
	{
		GD.Print(area);
	}
}


