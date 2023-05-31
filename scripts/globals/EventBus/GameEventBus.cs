using Godot;
using System;

public partial class GameEventBus : Node
{
    [Signal]
    public delegate void StartGameEventHandler(string LevelName);
    [Signal]
    public delegate void ResumeGameEventHandler();

    public void EmitStartGame(string LevelName)
    {
        EmitSignal("StartGame", LevelName);
    }

    public void EmitResumeGame()
    {
        EmitSignal("ResumeGame");
    }
}
