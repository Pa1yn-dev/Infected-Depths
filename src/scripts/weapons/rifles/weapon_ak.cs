using Godot;
using System;

public class weapon_ak : Node2D
{
    private AnimationPlayer weapon_animationplayer;

    public override void _Ready()
    {
        weapon_animationplayer = GetNode<AnimationPlayer>("Weapon_AnimationPlayer");
    }

    public void GetUserInput()
    {
        if(Input.IsActionJustPressed("left_click"))
        {
            weapon_animationplayer.Play("defaultak_atinputpressed");
        }

        else if(Input.IsActionPressed("left_click"))
        {
            weapon_animationplayer.Play("defaultak_whileinputheld");
        }

        else if(Input.IsActionJustReleased("left_click"))
        {
            weapon_animationplayer.Play("defaultak_atinputreleased");
        }

    }

    public override void _Process(float delta)
    {
        GetUserInput();
    }

}
