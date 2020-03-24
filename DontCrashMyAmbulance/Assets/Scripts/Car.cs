using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    private float distance = 1f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        checkCollisionAmbulance(collision);
        checkCollisionCars(collision);
    }

    private void checkCollisionAmbulance(Collider2D collision)
    {
        if (collision.GetComponent<Ambulance>())
        {
            Vector2 vehiclePosition = collision.bounds.center;
            Vector2 junctionPosition = transform.position;
            if (Vector2.Distance(vehiclePosition, junctionPosition) < distance)
            {
                print(1);
                FindObjectOfType<Game>().EndGame(false);
            }
        }
    }

    private void checkCollisionCars(Collider2D collision)
    {
        Car car = collision.GetComponent<Car>();
        if (car)
        {
            print("check");
            Vector2 vehiclePosition = collision.bounds.center;
            Vector2 junctionPosition = transform.position;

            if (Vector2.Distance(vehiclePosition, junctionPosition) < distance)
            {
                print("check1");
                if (GetComponent<SpriteRenderer>().color != car.GetComponent<SpriteRenderer>().color)
                {
                    print(2);
                    FindObjectOfType<Game>().EndGame(false);
                }
                else
                {
                    Vehicle vehicle = GetComponent<Vehicle>();
                    Vehicle otherVehicle = collision.GetComponent<Vehicle>();
                    if (isInverseDirection(vehicle.GetDirection(), otherVehicle.GetDirection()) || isInverseDirection(otherVehicle.GetDirection(), vehicle.GetDirection()))
                    {
                        print(3);
                        FindObjectOfType<Game>().EndGame(false);
                    }
                }
            }
        }
    }

    private bool isInverseDirection(Direction d1, Direction d2)
    {
        if ((d1 == Direction.Up && d2 == Direction.Down) || (d1 == Direction.Left && d2 == Direction.Right))
        {
            return true;
        }
        return false;
    }
}