using Godot;
using System;

public partial class Calculate : Node
{
	static public float GetDelta(float init, float final, float delta) {
		if(init < final)
			return Math.Min(init + delta, final);
		
		return Math.Max(init - delta, final);
	}
}
