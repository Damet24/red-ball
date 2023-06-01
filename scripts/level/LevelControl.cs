using Godot;
using System;

public partial class LevelControl : Node
{
    public String CurrentLevel = Levels.LevelTest;

    [Signal]
    public delegate void LevelReadyEventHandler();
	[Signal]
	public delegate void ChangeLevelEventHandler(string level);
	[Signal]
	public delegate void DeleteLevelEventHandler();

	public void EmitChangeLevelSignal (string level)
	{
		CurrentLevel = level;
		EmitSignal("ChangeLevel", level);
	}

	public void EmitLevelReadySignal()
	{
		EmitSignal("LevelReady");
	}

	public void EmitDeleteLevel()
	{
		EmitSignal("DeleteLevel");
	}
}
