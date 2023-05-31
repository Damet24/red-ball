using Godot;
using System;

public partial class GameControl : Node
{
    public ConfigFile _ConfigFile;
    public override void _Ready()
    {
        LoadConfig();
    }

    private void LoadConfig()
    {
        Error error = _ConfigFile.Load("user://config.cfg");
        if (error != Error.Ok)
        {
			GD.Print("Error loading config");
            return;
        }

		GD.Print(_ConfigFile.GetSections());
    }
}
