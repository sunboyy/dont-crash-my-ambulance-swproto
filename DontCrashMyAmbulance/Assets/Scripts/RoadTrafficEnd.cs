using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadTrafficEnd : MonoBehaviour
{
    Collider2D[] colliders;

    void OnTriggerEnter2D(Collider2D collision)
    {
        Car car = collision.GetComponent<Car>();
        if (car)
        {
            Destroy(car.gameObject);
        }
    }

}