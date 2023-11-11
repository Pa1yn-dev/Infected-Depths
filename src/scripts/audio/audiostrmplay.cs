using Godot;
using System;


public partial class audiostrmplay : Node
{
    private AudioStreamPlayer audioplayer;
    public void PlayAudio(Node input_parent_node, AudioStreamWav input_sample, String input_bus)
    {
        this.audioplayer = new AudioStreamPlayer();
        this.audioplayer.Bus = input_bus;
        this.audioplayer.Stream = input_sample;
        this.audioplayer.Connect("finished", new Callable(this.audioplayer, "queue_free"));
        input_parent_node.AddChild(this.audioplayer);

        this.audioplayer.Play();
    }   
}