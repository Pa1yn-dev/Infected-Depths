using Godot;
using System;

public class pause_menu : Control
{
    private Control pausemenu_controlnode;
    private CanvasLayer load_scenetransition;
    private Button resume_button;
    private Button settings_button;
    private Button exit_button;

    public override void _Ready()
    {
        pausemenu_controlnode = GetNode<Control>(".");
        load_scenetransition = GetNode<CanvasLayer>("/root/LoadingScreen");

        resume_button = GetNode<Button>("MarginContainer/CenterContainer/HBoxContainer/VBoxContainer/Resume");
        settings_button = GetNode<Button>("MarginContainer/CenterContainer/HBoxContainer/VBoxContainer/Settings");
        exit_button = GetNode<Button>("MarginContainer/CenterContainer/HBoxContainer/VBoxContainer/Exit");
    }

    public void GetUserInput()
    {
        if(resume_button.Pressed == true)
        {
            pausemenu_controlnode.Hide();
        }

        if(settings_button.Pressed == true)
        {

        }

        if(exit_button.Pressed == true)
        {
            load_scenetransition.Call("SceneTransition", "res://src/scenes/menu/main_menu.tscn");
        }
    }

    public override void _Input(InputEvent @event)
    {
        GetUserInput();
    }


}
