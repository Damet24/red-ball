using Godot;
using System;

public partial class PlayerEventBus : Node
{
    [Signal]
	public delegate void TakeDamageEventHandler();
}
