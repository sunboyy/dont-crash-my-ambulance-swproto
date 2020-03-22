using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TJunction : Junction
{
    [SerializeField] Direction emptyDirection;

    override protected void UpdateDirection()
    {
        switch (direction)
        {
            case Direction.Up:
                direction = Direction.Left;
                break;
            case Direction.Down:
                direction = Direction.Right;
                break;
            case Direction.Left:
                direction = Direction.Down;
                break;
            case Direction.Right:
                direction = Direction.Up;
                break;
        }
        if (direction == emptyDirection)
        {
            UpdateDirection();
        }
        RotateArrow();
    }
}
