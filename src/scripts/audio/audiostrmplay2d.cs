using Godot;
using System;


public partial class audiostrmplay2d : Node
{
    private AudioStreamPlayer2D audioplayer;
    public void PlayAudio(Node input_parent_node, AudioStreamSample input_sample, String input_bus)
    {
        audioplayer = new AudioStreamPlayer2D();
        audioplayer.Bus = input_bus;
        audioplayer.Stream = input_sample;
        audioplayer.Connect("finished", audioplayer, "queue_free");
        input_parent_node.AddChild(audioplayer);

        audioplayer.Play();
    }

    
}
