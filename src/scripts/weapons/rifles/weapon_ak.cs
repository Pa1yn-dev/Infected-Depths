using Godot;
using System;

public class weapon_ak : Node2D
{
    private AnimationPlayer weapon_animationplayer;
    private AudioStreamSample sample_akgunfire_sfx;
    private Node2D parent_node;

    public override void _Ready()
    {
        weapon_animationplayer = GetNode<AnimationPlayer>("Weapon_AnimationPlayer");

        sample_akgunfire_sfx = (AudioStreamSample)GD.Load("res://src/audio/sfx/GunshotAssaultRifle_BW.5_79.wav");
        parent_node = GetNode<Node2D>(".");
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

    public void call_audiostrmplay2d_gunfiresfx()
    {
        //Called from animation "defaultak_whileinputheld"
        var audiostrmplay2d = new audiostrmplay2d();
        audiostrmplay2d.PlayAudio(parent_node, sample_akgunfire_sfx, "SFX"); 
    }

    public override void _Process(float delta)
    {
        GetUserInput();
    }

}
