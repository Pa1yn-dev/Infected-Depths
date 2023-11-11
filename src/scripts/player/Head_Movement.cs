using Godot;
using System;

public partial class Head_Movement : KinematicBody2D
{
    [Export] public float rotation_rate = 100f;
    public int rotation_direction;
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public void MoveHead()
    {
        while (true)
        {
            bool isrotationve = false;
        
        isrotationve = !isrotationve;

        if (isrotationve == true)
        {
            rotation_direction = -1;
        }
        else
        {
            rotation_direction = 1;
        }

        }
        
         
    }


    public override void _Process(float delta)
    {
        MoveHead();
        Rotation = rotation_direction * rotation_rate * delta;
    }
}
