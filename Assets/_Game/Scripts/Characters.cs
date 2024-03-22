using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characters : MonoBehaviour
{
    public Vector2 objectStartPosition;
  
    public int posx;
    public int posy;
    public int moveSpeed;
    public RectTransform rectTransform;
    public int framelength = 4;
    public enum Direction
    {
        Right,
        Up,
        Down,
        Left
    }
    public Direction DetermineDirection(Vector2 moveDirection)
    {
        float angle = Vector2.SignedAngle(Vector2.right, moveDirection);

        if (angle >= -45 && angle < 45)
        {
            return Direction.Right;
        }
        else if (angle >= 45 && angle < 135)
        {
            return Direction.Up;
        }
        else if (angle >= -135 && angle < -45)
        {
            return Direction.Down;
        }
        else
        {
            return Direction.Left;
        }
    }
    
}
