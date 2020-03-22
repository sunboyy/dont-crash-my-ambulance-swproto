using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Junction : MonoBehaviour
{
    public Direction startArrow;
    Direction arrow;
    // Start is called before the first frame update
    void Start()
    {
        arrow = startArrow;
        setDirection();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void setDirection()
    {
        switch (arrow)
        {
            case Direction.Up:
                transform.localEulerAngles = new Vector3(0,0,90);
                break;
            case Direction.Down:
                transform.localEulerAngles = new Vector3(0,0,270);
                break;
            case Direction.Left:
                transform.localEulerAngles = new Vector3(0,0,180);
                break;
            case Direction.Right:
                transform.localEulerAngles = new Vector3(0,0,0);
                break;
        }
    }

    void OnMouseDown() {
        updateDirection();
    }

    void updateDirection() {
        Direction newArrow = Direction.Up;
        switch (arrow)
        {
            case Direction.Up:
                newArrow = Direction.Left;
                break;
            case Direction.Down:
                newArrow = Direction.Right;
                break;
            case Direction.Left:
                newArrow = Direction.Down;
                break;
            case Direction.Right:
                newArrow = Direction.Up;
                break;
        }
        arrow = newArrow;
        transform.Rotate( new Vector3( 0, 0, 90 ) );
    }
}
