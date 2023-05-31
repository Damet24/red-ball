using Godot;
using System;

public partial class GuiEventBus : Node
{
	
	[Signal]
	public delegate void ChangeMenuEventHandler(string GuiName);
	[Signal]
	public delegate void BackGuiEventHandler();

	public void EmitChangeMenu (string GuiName)
	{
		EmitSignal("ChangeMenu", GuiName);
	}

	public void EmitBackGui()
	{
		EmitSignal("BackGui");
	}
}
