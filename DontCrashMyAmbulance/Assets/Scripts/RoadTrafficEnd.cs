using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadTrafficEnd : MonoBehaviour
{
    Collider2D[] colliders;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name.Substring(0, 3) == "car")
        {
            Vector2 carPosition = collision.bounds.center;
            Vector2 junctionPosition = transform.position;
            if (Vector2.Distance(carPosition, junctionPosition) < 0.05)
            {
                Car car = collision.GetComponent<Car>();
                Destroy(car.gameObject);
                Destroy(car);
            }
        }
    }

}