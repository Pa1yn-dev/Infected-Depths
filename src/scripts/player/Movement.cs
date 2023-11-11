using Godot;
using System;

public class Movement : KinematicBody2D
{
    public Vector2 player_velocity = new Vector2();
    [Export] public float player_vhipmagnitude = 250f;
    [Export] public float player_vadsmagnitude = 200f;

    [Export] public float player_vacceleration = 2f;
    [Export] public float lerp_weight = 0.5f;


    float Lerp(float player_velocity_axis, float target_value, float weight)
    {
        // Greg Bahm inverted lerp equation [firstfloat * weight + secondfloat * (1 - weight)]
        // Lerp equation [firstfloat * (1 - weight) + secondfloat * weight]
        return player_velocity_axis * (1 - weight) + target_value * weight;

    }

    // Called when the node enters the scene tree for the first time.
    public void GetUserInput()
    {
        LookAt(GetGlobalMousePosition());

        player_velocity = new Vector2();

        
        if (Input.IsActionPressed("right"))
        {
            //player_velocity.x += 1;
            player_velocity.x = Math.Min(player_velocity.x + player_vacceleration, player_vhipmagnitude);
        }
        else if (!Input.IsActionPressed("right"))
        {
            player_velocity.x = Lerp(player_velocity.x, 0, lerp_weight);
        }
          
        if (Input.IsActionPressed("left"))
        {
            //player_velocity.x -= 1;
            player_velocity.x = Math.Max(player_velocity.x - player_vacceleration, -player_vhipmagnitude);
        }
        else if (!Input.IsActionPressed("left"))
        {
            
            player_velocity.x = Lerp(player_velocity.x, 0, lerp_weight);
            
        }
            
        if (Input.IsActionPressed("up"))
        {
            //player_velocity.y -= 1;
            player_velocity.y = Math.Max(player_velocity.y - player_vacceleration, -player_vhipmagnitude);
            
        }
        else if (!Input.IsActionPressed("up"))
        {
            player_velocity.y = Lerp(player_velocity.y, 0, lerp_weight);
        }
            
        if (Input.IsActionPressed("down"))
        {
            //player_velocity.y += 1;
            player_velocity.y = Math.Min(player_velocity.y + player_vacceleration, player_vhipmagnitude);
            
        }
        else if (!Input.IsActionPressed("down"))
        {
            player_velocity.y = Lerp(player_velocity.y, 0, lerp_weight);
        }
        
        // ADS
        if (Input.IsActionPressed("right_click"))
        {
            player_velocity = player_velocity.Normalized() * player_vadsmagnitude;
        }
 
        else
        {   
            player_velocity = player_velocity.Normalized() * player_vhipmagnitude;
        }
            
        
        

        
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
public override void _PhysicsProcess(float delta)
  {
      GetUserInput();
    
      player_velocity = MoveAndSlide(player_velocity);
      GD.Print(player_velocity);
      
  }
}
