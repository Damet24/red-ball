using Godot;
using System;

public partial class MainMenuButton : Button
{
	public override void _Ready()
	{
		Pressed += () => GetNode<GameEventBus>("/root/GameEventBus").EmitStopGame();
	}
}
