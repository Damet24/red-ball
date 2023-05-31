using Godot;
using System;

public partial class LevelLayout : Node2D
{
	private LevelControl levelControl;
	private string CurrentLevelName;

	private PackedScene LoadLevel()
	{
		return ResourceLoader.Load<PackedScene>(levelControl.CurrentLevel);
	}

	private void RemoveCurrentLevel()
	{
		if (GetChildCount() > 0)
		{
			RemoveChild(GetNode<Node>(CurrentLevelName));
		}
	}

	private void ChangeLevel()
	{
		RemoveCurrentLevel();
		var level = LoadLevel();
		var levelNode = level.Instantiate();
		CurrentLevelName = levelNode.Name;
		AddChild(levelNode);
		levelControl.EmitLevelReadySignal();
	}

	public override void _Ready()
	{
		levelControl = GetNode<LevelControl>("/root/LevelControl");
	}
}
