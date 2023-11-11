using Godot;
using System;


public partial class player_cursor : Line2D
{
    [Export] public float aimingcursor_length = 300f;

    [Export] public float offset_playerposition = 80f;
    
    public void DrawLineToCursor()
    {
        Vector2 player_position = Position;
        Vector2 mouseposition = GetLocalMousePosition();

        player_position.X += offset_playerposition;

        if ((player_position + mouseposition).Length() > aimingcursor_length)
        {
            float lengthdelta = ((player_position + mouseposition).Length() - aimingcursor_length) - offset_playerposition;

            mouseposition.X -= lengthdelta;
        }

        if(mouseposition.X < offset_playerposition)
        {
            mouseposition.X = offset_playerposition;
        }
        
        AddPoint(player_position);
        AddPoint(mouseposition);
    }
    
    public override void _Process(double delta)
    {
        ClearPoints();
        DrawLineToCursor();
    }
}
