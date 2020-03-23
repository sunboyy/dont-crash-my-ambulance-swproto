using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    [SerializeField] float initialSpeed;
    [SerializeField] float maxSpeed;

    float currentSpeed;
    Direction currentDirection;

    public void Initialize(Direction direction)
    {
        currentDirection = direction;
        currentSpeed = initialSpeed;
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

    public void ChangeDirection(Direction direction)
    {
        currentDirection = direction;
        UpdateVelocity();
    }

    public void SpeedUp()
    {
        currentSpeed *= 2;
        if (currentSpeed > maxSpeed)
        {
            currentSpeed = maxSpeed;
        }
        UpdateVelocity();
    }

    public void SpeedDown()
    {
        currentSpeed /= 2;
        if (currentSpeed < initialSpeed)
        {
            currentSpeed = initialSpeed;
        }
        UpdateVelocity();
    }
}
