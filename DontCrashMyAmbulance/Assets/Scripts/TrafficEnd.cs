using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficEnd : MonoBehaviour
{
    [SerializeField] Color color;
    [SerializeField] Direction direction;

    Game game;

    private void Start()
    {
        switch (direction)
        {
            case Direction.Up:
                transform.eulerAngles = new Vector3(0, 0, 180);
                break;
            case Direction.Right:
                transform.eulerAngles = new Vector3(0, 0, 90);
                break;
            case Direction.Down:
                transform.eulerAngles = new Vector3(0, 0, 0);
                break;
            case Direction.Left:
                transform.eulerAngles = new Vector3(0, 0, 270);
                break;
        }
        GetComponent<SpriteRenderer>().color = color;
        game = FindObjectOfType<Game>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Car car = collision.GetComponent<Car>();
        if (car)
        {
            Destroy(car.gameObject);
        }
    }

}