using Godot;
using System;

public partial class LevelControl : Node
{
    public String CurrentLevel = Levels.LevelTest;

    [Signal]
    public delegate void LevelReadyEventHandler();
	[Signal]
	public delegate void ChangeLevelEventHandler(string level);

	public void EmitChangeLevelSignal (string level)
	{
		CurrentLevel = level;
		EmitSignal("ChangeLevel", level);
	}

	public void EmitLevelReadySignal()
	{
		EmitSignal("LevelReady");
	}
}
