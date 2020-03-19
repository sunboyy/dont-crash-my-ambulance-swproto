using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ambulance : MonoBehaviour
{
    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeDirection(Direction direction)
    {
        Vector2 newVelocity = Vector2.zero;
        
        switch (direction)
        {
            case Direction.Up:
                newVelocity = new Vector2(0, 1f) * speed;
                break;
            case Direction.Down:
                newVelocity = new Vector2(0, -1f) * speed;
                break;
            case Direction.Left:
                newVelocity = new Vector2(-1f, 0) * speed;
                break;
            case Direction.Right:
                newVelocity = new Vector2(1f, 0) * speed;
                break;
        }
        GetComponent<Rigidbody2D>().velocity = newVelocity;
    }
}
