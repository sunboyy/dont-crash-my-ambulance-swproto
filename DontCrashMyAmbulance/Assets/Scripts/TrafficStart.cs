using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficStart : MonoBehaviour
{
    [SerializeField] GameObject carPrefab;
    [SerializeField] float spawnInterval = 5f;
    [SerializeField] Direction direction;
    [SerializeField] Color color;

    float currentTimer = 1;
    Game game;

    private void Start()
    {
        GetComponent<SpriteRenderer>().color = color;
        game = FindObjectOfType<Game>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTimer -= Time.deltaTime;
        if (currentTimer <= 0)
        {
            GameObject carObject = Instantiate(carPrefab, new Vector3(transform.position.x, transform.position.y, -2), Quaternion.identity);
            Vehicle vehicle = carObject.GetComponent<Vehicle>();
            game.AddActiveVehicle(vehicle);
            vehicle.GetComponent<SpriteRenderer>().color = color;
            vehicle.Initialize(direction, game.GetCurrentVelocity());
            currentTimer = spawnInterval;
        }
    }

    public void SetSpawnInterval(float interval)
    {
        currentTimer *= interval / spawnInterval;
        spawnInterval = interval;
    }
}
