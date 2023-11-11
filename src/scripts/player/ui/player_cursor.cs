using Godot;
using System;


public partial class player_cursor : Line2D
{
    [Export] public float aimingcursor_length = 50f;

    [Export] public float offset_playerposition = 50f;
    
    public void DrawLineToCursor()
    {
        Vector2 player_position = Position;
        Vector2 mouseposition = GetLocalMousePosition();

        player_position.x += offset_playerposition;

        if ((player_position + mouseposition).Length() > aimingcursor_length)
        {
            float lengthdelta = ((player_position + mouseposition).Length() - aimingcursor_length) - offset_playerposition;

            mouseposition.x -= lengthdelta;
            // Try putting this in if statement below
        }

        if(mouseposition.x < 0)
        {
            Math.Abs(mouseposition.x);
        }
        
        AddPoint(player_position);
        AddPoint(mouseposition);
        
    }
    
    public override void _Process(float delta)
    {
        ClearPoints();
        DrawLineToCursor();
        
    }
}
