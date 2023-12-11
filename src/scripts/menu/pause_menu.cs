using Godot;
using System;

public partial class pause_menu : Control
{
    private Control pausemenu_controlnode;
    private Control settingsmenu_node;
    private CanvasLayer load_scenetransition;
    private Button resume_button;
    private Button settings_button;
    private Button exit_button;

    private AudioStreamWav sample_menubuttononclick_sfx;

    public override void _Ready()
    {
        pausemenu_controlnode = GetNode<Control>(".");
        sample_menubuttononclick_sfx = (AudioStreamWav)GD.Load("res://src/audio/sfx/main_menu/menubuttonclick_01.wav");
        load_scenetransition = GetNode<CanvasLayer>("/root/LoadingScreen");

        resume_button = GetNode<Button>("MarginContainer/CenterContainer/HBoxContainer/VBoxContainer/Resume");
        settings_button = GetNode<Button>("MarginContainer/CenterContainer/HBoxContainer/VBoxContainer/Settings");
        exit_button = GetNode<Button>("MarginContainer/CenterContainer/HBoxContainer/VBoxContainer/Exit");

        settingsmenu_node = GetNode<Control>("./Settings_Menu");
        settingsmenu_node.Hide();
    }

    public void GetUserInput()
    {
        var audiostrmplay = new audiostrmplay();

        if(Input.IsActionPressed("escape"))
        {
            GetTree().Paused = true;
            pausemenu_controlnode.Show();
        }

        if(resume_button.ButtonPressed == true)
        {
            audiostrmplay.PlayAudio(pausemenu_controlnode, sample_menubuttononclick_sfx, "SFX");
            GetTree().Paused = false;
            pausemenu_controlnode.Hide();
        }

        if(settings_button.ButtonPressed == true)
        {
            audiostrmplay.PlayAudio(pausemenu_controlnode, sample_menubuttononclick_sfx, "SFX");
            settingsmenu_node.Show();   
        }

        if(exit_button.ButtonPressed == true)
        {
            audiostrmplay.PlayAudio(pausemenu_controlnode, sample_menubuttononclick_sfx, "SFX");
            load_scenetransition.Call("SceneTransition", "res://src/scenes/menu/main_menu.tscn");
        }
    }

    public override void _Input(InputEvent @event)
    {
        GetUserInput();
    }


}
