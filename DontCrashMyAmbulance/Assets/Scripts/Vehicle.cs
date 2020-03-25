using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    float currentSpeed;
    Direction currentDirection;

    public void Initialize(Direction direction, float speed)
    {
        currentDirection = direction;
        currentSpeed = speed;
        UpdateVelocity();
    }

    public void UpdateVelocity()
    {
        Vector2 newVelocity = Vector2.zero;
        switch (currentDirection)
        {
            case Direction.Up:
                newVelocity = new Vector2(0, 1f) * currentSpeed;
                break;
            case Direction.Down:
                newVelocity = new Vector2(0, -1f) * currentSpeed;
                break;
            case Direction.Left:
                newVelocity = new Vector2(-1f, 0) * currentSpeed;
                break;
            case Direction.Right:
                newVelocity = new Vector2(1f, 0) * currentSpeed;
                break;
        }
        GetComponent<Rigidbody2D>().velocity = newVelocity;
    }

    public Direction GetDirection()
    {
        return currentDirection;
    }

    public void ChangeDirection(Direction direction)
    {
        currentDirection = direction;
        UpdateVelocity();
    }
}
