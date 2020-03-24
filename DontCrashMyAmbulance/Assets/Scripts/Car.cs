using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    float distance = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CheckAmbulanceCollision(collision);
        CheckCarCollision(collision);
    }

    private void CheckAmbulanceCollision(Collider2D collision)
    {
        if (collision.GetComponent<Ambulance>())
        {
            Vector2 vehiclePosition = collision.bounds.center;
            Vector2 junctionPosition = transform.position;
            if (Vector2.Distance(vehiclePosition, junctionPosition) < distance)
            {
                FindObjectOfType<Game>().EndGame(false);
            }
        }
    }

    private void CheckCarCollision(Collider2D collision)
    {
        Car car = collision.GetComponent<Car>();
        if (car)
        {
            Vector2 vehiclePosition = collision.bounds.center;
            Vector2 junctionPosition = transform.position;

            if (Vector2.Distance(vehiclePosition, junctionPosition) < distance)
            {
                if (GetComponent<SpriteRenderer>().color != car.GetComponent<SpriteRenderer>().color)
                {
                    FindObjectOfType<Game>().EndGame(false);
                }
                else
                {
                    Vehicle vehicle = GetComponent<Vehicle>();
                    Vehicle otherVehicle = collision.GetComponent<Vehicle>();
                    if (vehicle.GetDirection() == OppositeOf(otherVehicle.GetDirection()))
                    {
                        FindObjectOfType<Game>().EndGame(false);
                    }
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
}