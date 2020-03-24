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
                direction = Direction.Right;
                break;
            case Direction.Down:
                direction = Direction.Left;
                break;
            case Direction.Left:
                direction = Direction.Up;
                break;
            case Direction.Right:
                direction = Direction.Down;
                break;
        }
        if (direction == emptyDirection)
        {
            UpdateDirection();
        }
        RotateArrow();
    }
}
