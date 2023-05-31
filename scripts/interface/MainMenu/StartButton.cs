using Godot;
using System;

public partial class StartButton : Button
{
    public override void _Ready()
    {
        Pressed += () => GetNode<GuiEventBus>("/root/GuiEventBus").EmitChangeMenu(Guis.MainMenu);
    }
}
