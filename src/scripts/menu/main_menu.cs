using Godot;
using System;

public class main_menu : Control
{
    private Button play_button;
    private Button settings_button;
    private Button credits_button;
    private Button exit_button;

    private CanvasLayer load_scenetransition;

    private AnimationPlayer menu_animationplayer;

    private Control settingsmenu_node;

    private AudioStreamSample sample_menubuttonsfx;
    private Control parent_node;

    public override void _Ready()
    {
        play_button = GetNode<Button>("MarginContainer/CenterContainer/HBoxContainer/VBoxContainer/VBoxContainer2/Play");
        settings_button = GetNode<Button>("MarginContainer/CenterContainer/HBoxContainer/VBoxContainer/VBoxContainer2/Settings");
        credits_button = GetNode<Button>("MarginContainer/CenterContainer/HBoxContainer/VBoxContainer/VBoxContainer2/Credits");
        exit_button = GetNode<Button>("MarginContainer/CenterContainer/HBoxContainer/VBoxContainer/VBoxContainer2/Exit");

        load_scenetransition = GetNode<CanvasLayer>("/root/LoadingScreen");

        menu_animationplayer = GetNode<AnimationPlayer>("Menu_AnimationPlayer");

        settingsmenu_node = GetNode<Control>("Sub_Menus/Settings_Menu");
        settingsmenu_node.Hide();

        sample_menubuttonsfx = (AudioStreamSample)GD.Load("res://src/audio/sfx/main_menu/menubuttonclick_01.wav");
        parent_node = GetNode<Control>(".");
    }

    public void GetUserInput()
    {
        var audiostrmplay = new audiostrmplay();
        
        if(play_button.Pressed == true)
        {
            
            load_scenetransition.Call("SceneTransition", "res://src/scenes/main/main.tscn");
            audiostrmplay.PlayAudio(parent_node, sample_menubuttonsfx, "SFX");

        }

        if(settings_button.Pressed == true)
        {
            settingsmenu_node.Show();
            audiostrmplay.PlayAudio(parent_node, sample_menubuttonsfx, "SFX");
            
        }

        if(exit_button.Pressed == true)
        {
            audiostrmplay.PlayAudio(parent_node, sample_menubuttonsfx, "SFX");
            GetTree().Quit(0);
        }

    }


//  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        menu_animationplayer.Play("title_movement");
    }

    public override void _Input(InputEvent @event)
    {
        GetUserInput();
    }
}
