using Godot;
using System;

public partial class Player : CharacterBody2D
{
    [Signal]
    public delegate void ColorStateChangedEventHandler(string color);

    public string ColorState = ColorStates.RED;

    [Export]
    public float MaxVelocityX = 200;
    [Export]
    public float MaxVelocityY = 900;
    [Export]
    public float JumpForce = 290;
    [Export]
    public float GroundAcc = 100;
    [Export]
    public float GroundFric = 100;
    [Export]
    public float AirAcc = 100;
    [Export]
    public float AirFric = 100;
    [Export]
    public float GravityAcc = 9;
    [Export]
    public float GravityForce = 900;
    private float TempAcc = 0;
    private float TempFric = 0;
    Vector2 MovementVelocity = new Vector2();
    private int DoubleJump = 1;
    private int MaxDoubleJump = 1;

    public override void _Process(double delta)
    {
        if (IsOnFloor())
        {
            if (DoubleJump <= 0) ResetDoubleJump();
            TempAcc = GroundAcc;
            TempFric = GroundFric;
            MovementVelocity.Y = 0;
        }
        else
        {
            TempAcc = AirAcc;
            TempFric = AirFric;
        }
    }

    public override void _PhysicsProcess(double delta)
    {
        float Direction = Input.GetAxis("ui_left", "ui_right");

        if (Direction != 0)
        {
            MovementVelocity.X = Calculate.GetDelta(Velocity.X, MaxVelocityX * Direction, TempAcc);
        }
        else
        {
            MovementVelocity.X = Calculate.GetDelta(Velocity.X, 0, TempFric);
        }

        if (!IsOnFloor()) ApplyGravity();

        if (Input.IsActionJustPressed("ui_up"))
        {
            if (IsOnFloor()) Jump();

            if (DoubleJump > 0 && !IsOnFloor())
            {
                Jump();
                DoubleJump--;
            }
        }

        if (Input.IsActionJustReleased("ui_up"))
            if (MovementVelocity.Y < 0) MovementVelocity.Y *= 0.5f;

        Velocity = MovementVelocity;
        MoveAndSlide();
    }

    private void Jump()
    {
        MovementVelocity.Y = -JumpForce;
    }

    private void ResetDoubleJump()
    {
        DoubleJump = MaxDoubleJump;
    }

    private void ApplyGravity()
    {
        MovementVelocity.Y = Calculate.GetDelta(Velocity.Y, GravityForce, GravityAcc);
    }
}
