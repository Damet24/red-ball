using Godot;
using System;

public partial class ResumeButton : Button
{
	public override void _Ready()
	{
		Pressed += () => GetNode<GameEventBus>("/root/GameEventBus").EmitResumeGame();
	}
}
