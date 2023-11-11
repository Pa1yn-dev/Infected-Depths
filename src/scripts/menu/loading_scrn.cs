using Godot;
using System;

public class loading_scrn : CanvasLayer
{
   

    private string target = "res://src/scenes/main/main.tscn";
    private AnimationPlayer loadingscrn_animationplyr;

    public override void _Ready()
    {
      this.loadingscrn_animationplyr = GetNode<AnimationPlayer>("AnimationPlayer");
      
      

    }
    public void SceneTransition()
    {
      GD.Print(loadingscrn_animationplyr);
      loadingscrn_animationplyr.Play("dissolve");
      loadingscrn_animationplyr.PlayBackwards("dissolve");

        
      //loadingscrn_animationplyr.Connect("animation_finished", loadingscrn_animationplyr, "" );
      //GetTree().ChangeScene(target);
      //loadingscrn_animationplyr.Play("dissolve_backwards");

    }
      
      public override void _Process(float delta)
    {
        SceneTransition();
      
    }


    


     
     

   

}
