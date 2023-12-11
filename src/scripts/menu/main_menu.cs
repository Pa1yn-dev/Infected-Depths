using Godot;
using System;

public partial class main_menu : Control
{
    private Button play_button;
    private Button settings_button;
    private Button credits_button;
    private Button exit_button;

    private CanvasLayer load_scenetransition;

    private AnimationPlayer menu_animationplayer;

    private Control settingsmenu_node;
    private Control creditsmenu_node;

    private AudioStreamWav sample_menubuttononclick_sfx;
    private Control parent_node;

    public override void _Ready()
    {
        play_button = GetNode<Button>("MarginContainer/CenterContainer/HBoxContainer/VBoxContainer/VBoxContainer2/Play");
        settings_button = GetNode<Button>("MarginContainer/CenterContainer/HBoxContainer/VBoxContainer/VBoxContainer2/Settings");
        credits_button = GetNode<Button>("MarginContainer/CenterContainer/HBoxContainer/VBoxContainer/VBoxContainer2/Credits");
        exit_button = GetNode<Button>("MarginContainer/CenterContainer/HBoxContainer/VBoxContainer/VBoxContainer2/Exit");

        load_scenetransition = GetNode<CanvasLayer>("/root/LoadingScreen");

        menu_animationplayer = GetNode<AnimationPlayer>("Menu_AnimationPlayer");

        settingsmenu_node = GetNode<Control>("ScreenEffectsOverlay/Sub_Menus/Settings_Menu");
        settingsmenu_node.Hide();

        creditsmenu_node = GetNode<Control>("ScreenEffectsOverlay/Sub_Menus/Credits_Menu");
        creditsmenu_node.Hide();

        sample_menubuttononclick_sfx = (AudioStreamWav)GD.Load("res://src/audio/sfx/main_menu/menubuttonclick_01.wav");
        parent_node = GetNode<Control>(".");
    }

    public void GetUserInput()
    {
        var audiostrmplay = new audiostrmplay();
        
        if(play_button.IsHovered() == true)
        {
            
        }

        if(play_button.ButtonPressed == true)
        { 
            load_scenetransition.Call("SceneTransition", "res://src/scenes/main/main.tscn");
            audiostrmplay.PlayAudio(parent_node, sample_menubuttononclick_sfx, "SFX");
        }

        if(credits_button.IsHovered() == true)
        {

        }

        if(credits_button.ButtonPressed == true)
        {
            creditsmenu_node.Show();
            audiostrmplay.PlayAudio(parent_node, sample_menubuttononclick_sfx, "SFX");  
        }


        if(settings_button.IsHovered() == true)
        {

        }

        if(settings_button.ButtonPressed == true)
        {
            settingsmenu_node.Show();
            audiostrmplay.PlayAudio(parent_node, sample_menubuttononclick_sfx, "SFX");   
        }

        
        if(exit_button.IsHovered() == true)
        {

        }

        if(exit_button.ButtonPressed == true)
        {
            audiostrmplay.PlayAudio(parent_node, sample_menubuttononclick_sfx, "SFX");
            GetTree().Quit(0);
        }

    }


//  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        menu_animationplayer.Play("title_movement");
    }

    public override void _Input(InputEvent @event)
    {
        GetUserInput();
    }
}
