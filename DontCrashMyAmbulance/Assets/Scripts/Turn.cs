using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
    // Direction CCW, Other direction is 90 deg CW from this direction
    [SerializeField] Direction primaryDirection;

    private void Start()
    {
        switch (primaryDirection)
        {
            case Direction.Up:
                transform.eulerAngles = new Vector3(0, 0, 0);
                break;
            case Direction.Right:
                transform.eulerAngles = new Vector3(0, 0, 270);
                break;
            case Direction.Down:
                transform.eulerAngles = new Vector3(0, 0, 180);
                break;
            case Direction.Left:
                transform.eulerAngles = new Vector3(0, 0, 90);
                break;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Vehicle vehicle = collision.GetComponent<Vehicle>();
        if (vehicle)
        {
            Vector2 vehiclePosition = collision.bounds.center;
            Vector2 junctionPosition = transform.position;
            if (Vector2.Distance(vehiclePosition, junctionPosition) < 0.1)
            {
                if (vehicle.GetDirection() == OppositeOf(primaryDirection))
                {
                    vehicle.ChangeDirection(SecondaryOf(primaryDirection));
                }
                else if (vehicle.GetDirection() == OppositeOf(SecondaryOf(primaryDirection)))
                {
                    vehicle.ChangeDirection(primaryDirection);
                }
            }
        }
    }

    Direction OppositeOf(Direction direction)
    {
        switch (direction)
        {
            case Direction.Up:
                return Direction.Down;
            case Direction.Down:
                return Direction.Up;
            case Direction.Left:
                return Direction.Right;
            case Direction.Right:
                return Direction.Left;
        }
        return Direction.Up;
    }

    Direction SecondaryOf(Direction direction)
    {
        switch (direction)
        {
            case Direction.Up:
                return Direction.Right;
            case Direction.Down:
                return Direction.Left;
            case Direction.Left:
                return Direction.Up;
            case Direction.Right:
                return Direction.Down;
        }
        return Direction.Up;
    }
}
