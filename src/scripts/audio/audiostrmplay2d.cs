using Godot;
using System;


public class audiostrmplay2d : Node
{
    public void PlayAudio(AudioStreamPlayer2D audioplayer, AudioStreamSample sample)
    {

        audioplayer = new AudioStreamPlayer2D();
        audioplayer.Stream = sample;
        audioplayer.Connect("finished", audioplayer, "queue_free");
        audioplayer.AddChild(audioplayer);
        audioplayer.Play();
        
    }
}
