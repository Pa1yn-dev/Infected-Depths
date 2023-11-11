using Godot;
using System;

public class main_menu : Control
{
    private Button play_button;
    private Button settings_button;
    private Button credits_button;
    private Button exit_button;

    private CanvasLayer load_scenetransition;

    public override void _Ready()
    {
        play_button = GetNode<Button>("MarginContainer/CenterContainer/HBoxContainer/VBoxContainer/VBoxContainer2/Play");
        settings_button = GetNode<Button>("MarginContainer/CenterContainer/HBoxContainer/VBoxContainer/VBoxContainer2/Settings");
        credits_button = GetNode<Button>("MarginContainer/CenterContainer/HBoxContainer/VBoxContainer/VBoxContainer2/Credits");
        exit_button = GetNode<Button>("MarginContainer/CenterContainer/HBoxContainer/VBoxContainer/VBoxContainer2/Exit");

        load_scenetransition = GetNode<CanvasLayer>("/root/LoadingScreen");



    }

    public void GetUserInput()
    {
        if(play_button.Pressed == true)
        {
            load_scenetransition.Call("SceneTransition", "res://src/scenes/main/main.tscn");
        }

    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        GetUserInput();
      
    }
}