using Godot;
using System;

public partial class GuiEventBus : Node
{
	[Signal]
	public delegate void ChangeMenuEventHandler(string GuiName, bool WihtBackground);
	[Signal]
	public delegate void BackGuiEventHandler();
	[Signal]
	public delegate void HideAllEventHandler(bool background);

	public void EmitChangeMenu (string GuiName, bool WihtBackground = false)
	{
		EmitSignal("ChangeMenu", GuiName, WihtBackground);
	}

	public void EmitBackGui()
	{
		EmitSignal("BackGui");
	}

	public void EmitHideAll(bool background = true)
	{
		EmitSignal("HideAll", background);
	}
}
