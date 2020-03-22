using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ambulance : MonoBehaviour
{
    [SerializeField] float initialSpeed;
    [SerializeField] float maxSpeed;

    float currentSpeed;
    public Direction currentDirection;

    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = initialSpeed;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void UpdateVelocity()
    {
        Debug.Log(currentDirection);
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
