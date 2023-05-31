using Godot;
using System;

public partial class SpikeContent : Node2D
{
    public void OnBodyEntered(Node Object)
    {
        if (Object is Object)
        {
            ((Player)Object).DamegController();
        }
    }
}
