using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] Button startButton;
    [SerializeField] Button accelerateButton;
    [SerializeField] Button brakeButton;
    [SerializeField] Vehicle ambulance;
    [SerializeField] Direction initialAmbulanceDirection;
    [SerializeField] float initialSpeed;
    [SerializeField] TrafficStart trafficStart;

    public float currentSpeed;
    List<Vehicle> vehicles = new List<Vehicle>();

    void Start()
    {
        currentSpeed = initialSpeed;
    }
    public void StartGame()
    {
        AddActiveVehicle(ambulance);
        accelerateButton.gameObject.SetActive(true);
        brakeButton.gameObject.SetActive(true);
        startButton.gameObject.SetActive(false);
        ambulance.Initialize(initialAmbulanceDirection, currentSpeed);
    }

    public void EndGame()
    {
        FindObjectOfType<SceneLoader>().LoadEndScene();
    }

    public void AddActiveVehicle(Vehicle vehicle)
    {
        vehicles.Add(vehicle);
    }

    public void SpeedUp()
    {
        float newSpeed = currentSpeed * 2;
        foreach (Vehicle v in vehicles)
        {
            newSpeed = v.SetSpeed(newSpeed);
        }
        trafficStart.SetSpeed(currentSpeed / newSpeed);
        currentSpeed = newSpeed;
    }

    public void SpeedDown()
    {
        float newSpeed = currentSpeed / 2;
        foreach (Vehicle v in vehicles)
        {
            newSpeed = v.SetSpeed(newSpeed);
        }
        trafficStart.SetSpeed(currentSpeed / newSpeed);
        currentSpeed = newSpeed;
    }
}
