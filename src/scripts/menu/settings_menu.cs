using Godot;
using System;

public class settings_menu : Control
{
    private Control settingsmenu_controlnode;
    private HSlider masteraudiovol_slider;
    private HSlider musicvol_slider;

    private int masterbus;
    private int musicbus;
    private int sfxbus;
    private HSlider sfxvol_slider;
    private Button save_button;
    private Button close_button;

    public override void _Ready()
    {
        settingsmenu_controlnode = GetNode<Control>(".");
        masteraudiovol_slider = GetNode<HSlider>("MarginContainer/CenterContainer/HBoxContainer/VBoxContainer/Master_Audio_Level/HSlider");
        musicvol_slider = GetNode<HSlider>("MarginContainer/CenterContainer/HBoxContainer/VBoxContainer/Music_Audio_Level/HSlider");
        sfxvol_slider = GetNode<HSlider>("MarginContainer/CenterContainer/HBoxContainer/VBoxContainer/SFX_Audio_Level/HSlider");

        masterbus = AudioServer.GetBusIndex("Master");
        musicbus = AudioServer.GetBusIndex("Music");
        sfxbus = AudioServer.GetBusIndex("SFX");

        save_button = GetNode<Button>("MarginContainer/CenterContainer/HBoxContainer/VBoxContainer/VBoxContainer/HSplitContainer/Save");
        close_button = GetNode<Button>("MarginContainer/CenterContainer/HBoxContainer/VBoxContainer/VBoxContainer/HSplitContainer/Close");
    }

    public void GetUserInput()
    {
        if(close_button.Pressed == true)
        {
            settingsmenu_controlnode.Hide();
        }

        if(close_button.Pressed == false)
        {
            // Call custom save_settings method
        }
    }

    public void ProcessUserInteraction()
    {
        AudioServer.SetBusVolumeDb(masterbus, (float)masteraudiovol_slider.Value);
        AudioServer.SetBusVolumeDb(musicbus, (float)musicvol_slider.Value);
        AudioServer.SetBusVolumeDb(sfxbus, (float)sfxvol_slider.Value);

    }

    public override void _Process(float delta)
    {
        
        GetUserInput();
        ProcessUserInteraction();
    }


}
