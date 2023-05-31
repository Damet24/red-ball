using Godot;
using System;

public partial class Spike : Area2D
{
    public override void _Ready()
    {
        var Parent = GetParent<SpikeContent>();
        BodyEntered += Parent.OnBodyEntered;
    }
}
