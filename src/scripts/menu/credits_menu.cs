using Godot;
using System;

public partial class credits_menu : Control
{
	private Button close_button;
	private Control creditsmenu_node;
	private AudioStreamWav sample_menubuttononclick_sfx;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		creditsmenu_node = GetNode<Control>(".");
		sample_menubuttononclick_sfx = (AudioStreamWav)GD.Load("res://src/audio/sfx/main_menu/menubuttonclick_01.wav");
		close_button = GetNode<Button>("MarginContainer/CenterContainer/HBoxContainer/VBoxContainer/VBoxContainer2/Close");
	}

	public void GetUserInput()
    {
		var audiostrmplay = new audiostrmplay();

        if(close_button.ButtonPressed == true)
        {
			audiostrmplay.PlayAudio(creditsmenu_node, sample_menubuttononclick_sfx, "SFX");
            creditsmenu_node.Hide();
        }

    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		GetUserInput();
	}
}
