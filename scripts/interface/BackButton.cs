using Godot;
using System;

public partial class BackButton : Button
{
	public override void _Ready()
	{
		Pressed += () =>  GetNode<GuiEventBus>("/root/GuiEventBus").EmitBackGui();
	}
}
