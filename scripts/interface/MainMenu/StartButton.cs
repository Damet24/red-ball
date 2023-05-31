using Godot;
using System;

public partial class StartButton : Button
{
    public override void _Ready()
    {
        Pressed += () => GetNode<GameEventBus>("/root/GameEventBus").EmitStartGame(Levels.LevelTest);
    }
}
