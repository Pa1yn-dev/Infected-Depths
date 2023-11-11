using Godot;
using System;

public partial class audiobusmanager : Node
{
    private float processed_defaultbusvol;

    public float GetDefaultBusVolume(string input_busname)
    {
        this.processed_defaultbusvol = Mathf.DbToLinear(AudioServer.GetBusVolumeDb(AudioServer.GetBusIndex(input_busname)));
        
        return this.processed_defaultbusvol;
    }
    public void ChangeBusVolume(string input_busname, float raw_sliderinput)
    {
        AudioServer.SetBusVolumeDb(AudioServer.GetBusIndex(input_busname), Mathf.LinearToDb(raw_sliderinput));
    }
}
