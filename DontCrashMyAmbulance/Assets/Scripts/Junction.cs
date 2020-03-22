using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Junction : MonoBehaviour
{
    [SerializeField] Direction direction;

    Collider2D[] colliders;
    // Start is called before the first frame update
    void Start()
    {
        RotateArrow();
    }

    // Update is called once per frame
    void Update()
    {
         colliders = Physics2D.OverlapCircleAll(transform.position, 0f);
         if (colliders.Length > 0) {
             UpdateCarDirection();
         }
    }

    void RotateArrow()
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

    void UpdateDirection() {
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

    void UpdateCarDirection()
    {
        for(int i = 0; i < colliders.Length; i++) {
            if(colliders[i].name == "Ambulance") {
                Vector2 carPosition = colliders[i].bounds.center;
                Vector2 junctionPosition = transform.position;
                if(Vector2.Distance(carPosition, junctionPosition) < 0.05){
                    Ambulance car = colliders[i].GetComponent<Ambulance>();
                    car.ChangeDirection(direction);
                }
            }
        }
    }
}
