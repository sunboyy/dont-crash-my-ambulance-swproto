using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficStart : MonoBehaviour
{
    [SerializeField] GameObject carPrefab;
    [SerializeField] Direction direction;
    [SerializeField] Color color;

    float carVelocity = 0.256f;
    float spawnInterval = 5f;
    float currentTimer = 0;

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
    }

    // Update is called once per frame
    void Update()
    {
        currentTimer -= Time.deltaTime;
        if (currentTimer <= 0)
        {
            Spawn();
            currentTimer = spawnInterval;
        }
    }

    void Spawn()
    {
        GameObject carObject = Instantiate(carPrefab, new Vector3(transform.position.x, transform.position.y, -2), Quaternion.identity);
        Vehicle vehicle = carObject.GetComponent<Vehicle>();
        vehicle.GetComponent<SpriteRenderer>().color = color;
        vehicle.Initialize(direction, carVelocity);
    }
}
