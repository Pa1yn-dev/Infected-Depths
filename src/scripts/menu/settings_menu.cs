using Godot;
using System;

public partial class settings_menu : Control
{
    private Control settingsmenu_controlnode;
    private HSlider masteraudiovol_slider;
    private HSlider musicvol_slider;
    private HSlider sfxvol_slider;
    private Button save_button;
    private Button close_button;

    public override void _Ready()
    {
        settingsmenu_controlnode = GetNode<Control>(".");
        masteraudiovol_slider = GetNode<HSlider>("MarginContainer/CenterContainer/HBoxContainer/VBoxContainer/Master_Audio_Level/HSlider");
        musicvol_slider = GetNode<HSlider>("MarginContainer/CenterContainer/HBoxContainer/VBoxContainer/Music_Audio_Level/HSlider");
        sfxvol_slider = GetNode<HSlider>("MarginContainer/CenterContainer/HBoxContainer/VBoxContainer/SFX_Audio_Level/HSlider");

        var audiobusmanager = new audiobusmanager();
        masteraudiovol_slider.Value = audiobusmanager.GetDefaultBusVolume("Master");
        musicvol_slider.Value = audiobusmanager.GetDefaultBusVolume("Music");
        sfxvol_slider.Value = audiobusmanager.GetDefaultBusVolume("SFX");
        
        save_button = GetNode<Button>("MarginContainer/CenterContainer/HBoxContainer/VBoxContainer/VBoxContainer/HSplitContainer/Save");
        close_button = GetNode<Button>("MarginContainer/CenterContainer/HBoxContainer/VBoxContainer/VBoxContainer/HSplitContainer/Close");
    }

    public void GetUserInput()
    {
        if(close_button.ButtonPressed == true)
        {
            settingsmenu_controlnode.Hide();
        }

        if(save_button.ButtonPressed == false)
        {
            // Call custom save_settings method
        }
    }

    public void ProcessUserInteraction()
    {
        var audiobusmanager = new audiobusmanager();
        audiobusmanager.ChangeBusVolume("Master", (float)masteraudiovol_slider.Value);
        audiobusmanager.ChangeBusVolume("Music", (float)musicvol_slider.Value);
        audiobusmanager.ChangeBusVolume("SFX", (float)sfxvol_slider.Value);
    }

    public override void _Process(double delta)
    {
        
        GetUserInput();
        ProcessUserInteraction();
    }


}
