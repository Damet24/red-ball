using Godot;
using System;

public partial class PlayerSprite : Sprite2D
{
	
	private Player player;

	public override void _Ready()
	{
		player = GetParent<Player>();
		player.ColorStateChanged += OnChangeColorState;
		Modulate = Color.FromHtml(player.ColorState);
	}

	private void OnChangeColorState(string color)
	{
		Modulate = Color.FromHtml(color);
	}
}
