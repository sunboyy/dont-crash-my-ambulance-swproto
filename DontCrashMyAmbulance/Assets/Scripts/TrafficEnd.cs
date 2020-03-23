using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficEnd : MonoBehaviour
{
    [SerializeField] Color color;

    private void Start()
    {
        GetComponent<SpriteRenderer>().color = color;
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