using Godot;
using System;

public class audiobusmanager : Node
{
    private float processed_defaultbusvol;

    public float GetDefaultBusVolume(string input_busname)
    {
        this.processed_defaultbusvol = GD.Db2Linear(AudioServer.GetBusVolumeDb(AudioServer.GetBusIndex(input_busname)));
        
        return this.processed_defaultbusvol;
    }
    public void ChangeBusVolume(string input_busname, float raw_sliderinput)
    {
        AudioServer.SetBusVolumeDb(AudioServer.GetBusIndex(input_busname), GD.Linear2Db(raw_sliderinput));
    }
}
