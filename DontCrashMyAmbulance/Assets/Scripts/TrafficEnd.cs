using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficEnd : MonoBehaviour
{
    [SerializeField] Color color;

    Game game;

    private void Start()
    {
        GetComponent<SpriteRenderer>().color = color;
        game = FindObjectOfType<Game>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Car car = collision.GetComponent<Car>();
        if (car)
        {
            game.RemoveActiveVehicle(collision.GetComponent<Vehicle>());
            Destroy(car.gameObject);
        }
    }

}