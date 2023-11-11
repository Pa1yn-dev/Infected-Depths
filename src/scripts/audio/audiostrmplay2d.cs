using Godot;
using System;


public partial class audiostrmplay2d : Node
{
    private AudioStreamPlayer2D audioplayer;
    public void PlayAudio(Node input_parent_node, AudioStreamSample input_sample, String input_bus)
    {
        this.audioplayer = new AudioStreamPlayer2D();
        this.audioplayer.Bus = input_bus;
        this.audioplayer.Stream = input_sample;
        this.audioplayer.Connect("finished", this.audioplayer, "queue_free");
        input_parent_node.AddChild(this.audioplayer);

        this.audioplayer.Play();
    }

    
}
