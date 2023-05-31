using Godot;
using System;

public partial class FullscreenButton : Button
{
	public override void _Ready()
	{
		Pressed += () => {
			if ( DisplayServer.WindowGetMode() != DisplayServer.WindowMode.Fullscreen)
			{
				DisplayServer.WindowSetMode(DisplayServer.WindowMode.Fullscreen);
			}
			else 
			{
				DisplayServer.WindowSetMode(DisplayServer.WindowMode.Windowed);
			}
		};
	}
}
