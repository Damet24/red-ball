using Godot;
using System;

public partial class PlayerEventBus : Node
{
    [Signal]
    public delegate void IsDeathEventHandler(int Lives);
    [Signal]
    public delegate void SetLivesEventHandler(int Lives);
    [Signal]
    public delegate void ColorStateChangedEventHandler(Color Color);

    public void EmitChangeColor(Color _Color)
    {
        EmitSignal("ColorStateChanged", _Color);
    }

    public void EmitIsDeath(int Lives)
    {
        EmitSignal("IsDeath", Lives);
    }

    public void EmitSetLives (int Lives)
    {
        GD.Print("Emit set lives signal");
        EmitSignal("SetLives", Lives);
    }
}
