using Godot;
using System;

public partial class PlayerSprite : Sprite2D
{
	
	private Player player;

	public override void _Ready()
	{
		player = GetParent<Player>();
		Modulate = player.color;
		GetNode<PlayerEventBus>("/root/PlayerEventBus").ColorStateChanged += OnChangeColorState;
	}

	private void OnChangeColorState(Color _Color)
	{
		Modulate = _Color;
	}
}
