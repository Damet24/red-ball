using Godot;
using System;

public partial class InGameOptionsButton : Button
{
	public override void _Ready()
	{
		Pressed += () => GetNode<GuiEventBus>("/root/GuiEventBus").EmitChangeMenu(Guis.OptionsMenu, true);
	}
}
