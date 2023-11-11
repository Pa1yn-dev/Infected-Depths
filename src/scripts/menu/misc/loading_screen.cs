using Godot;
using System;

public partial class loading_screen : CanvasLayer
{
    private string target;
    private AnimationPlayer loadingscrn_animationplyr;

    public async void SceneTransition(string input)
    {
      this.target = input;
      this.loadingscrn_animationplyr = GetNode<AnimationPlayer>("Loading_Screen_AnimationPlayer");
      this.loadingscrn_animationplyr.Play("dissolve");

      await ToSignal(this.loadingscrn_animationplyr, "animation_finished");
      GetTree().ChangeSceneToFile(this.target);
      this.loadingscrn_animationplyr.PlayBackwards("dissolve");
      
    } 
}
