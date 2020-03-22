using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Junction : MonoBehaviour
{
    [SerializeField] protected Direction direction;

    // Start is called before the first frame update
    void Start()
    {
        RotateArrow();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Ambulance ambulance = collision.GetComponent<Ambulance>();
        Car car = collision.GetComponent<Car>();

        Vector2 vehiclePosition = collision.bounds.center;
        Vector2 junctionPosition = transform.position;
        if (Vector2.Distance(vehiclePosition, junctionPosition) < 0.05)
        {
            if (ambulance)
            {
                ambulance.ChangeDirection(direction);
            }
            else if (car)
            {
                car.ChangeDirection(direction);
            }
        }
    }

    protected void RotateArrow()
    {
        switch (direction)
        {
            case Direction.Up:
                transform.localEulerAngles = new Vector3(0, 0, 90);
                break;
            case Direction.Down:
                transform.localEulerAngles = new Vector3(0, 0, 270);
                break;
            case Direction.Left:
                transform.localEulerAngles = new Vector3(0, 0, 180);
                break;
            case Direction.Right:
                transform.localEulerAngles = new Vector3(0, 0, 0);
                break;
        }
    }

    void OnMouseDown() {
        UpdateDirection();
    }

    protected virtual void UpdateDirection() {
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
        RotateArrow();
    }
}
