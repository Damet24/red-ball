using Godot;
using System;

public partial class Damage : Area2D
{
	private void OnBodyEntered (Player player)
	{
		player.DamegController();
	}
}
