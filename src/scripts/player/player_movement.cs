using Godot;
using System;

public partial class player_movement : CharacterBody2D
{
    public Vector2 player_velocity = Vector2.Zero;
    public Vector2 axis_input = Vector2.Zero;

    [Export] public float player_vhipvelocity = 250f;
    [Export] public float player_vadsvelocity = 200f;
    [Export] public float lerp_weight = 0.1f;

    // Called when the node enters the scene tree for the first time.
    public void GetUserInput()
    {
        LookAt(GetGlobalMousePosition());

        axis_input.X = Input.GetActionStrength("right") - Input.GetActionStrength("left");
        axis_input.Y = Input.GetActionStrength("down") - Input.GetActionStrength("up");

        if(!Input.IsActionPressed("right_click"))
        {
            axis_input = axis_input.Normalized() * player_vhipvelocity;
        }
        else
        {
            axis_input = axis_input.Normalized() * player_vadsvelocity;
        }

        player_velocity = player_velocity.Lerp(axis_input, lerp_weight);

        // Apply calculated player_velocity to character2d.Velocity for MoveAndSlide (Godot 4)
        Velocity = player_velocity;
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _PhysicsProcess(double delta)
    {
        GetUserInput();
    
        MoveAndSlide();
    }
}
