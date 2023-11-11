using Godot;
using System;

public class loading_scrn : CanvasLayer
{
    private string target;
    private AnimationPlayer loadingscrn_animationplyr;

    public void SceneTransition(string input)
    {
      this.target = input;
      this.loadingscrn_animationplyr = GetNode<AnimationPlayer>("AnimationPlayer");
      this.loadingscrn_animationplyr.Play("dissolve");
      
    }

    public void Scene_load()
    {
      //Called from Animation player, end of dissolve track.
      GetTree().ChangeScene(this.target);
      this.loadingscrn_animationplyr.PlayBackwards("dissolve");
    }
      
     
     

   

}
