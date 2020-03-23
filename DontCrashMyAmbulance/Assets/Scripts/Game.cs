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
    [SerializeField] Text speedInterface;

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
        if (newSpeed != currentSpeed)
        {
            trafficStart.SetSpeed(currentSpeed / newSpeed);
            setSpeedInterface(newSpeed > currentSpeed);
            currentSpeed = newSpeed;
        }
    }

    public void SpeedDown()
    {
        float newSpeed = currentSpeed / 2;
        foreach (Vehicle v in vehicles)
        {
            newSpeed = v.SetSpeed(newSpeed);
        }

        if (newSpeed != currentSpeed)
        {
            trafficStart.SetSpeed(currentSpeed / newSpeed);
            setSpeedInterface(newSpeed > currentSpeed);
            currentSpeed = newSpeed;
        } 
    }

    void setSpeedInterface(bool isSpeedUp)
    {
        print(speedInterface.text);
        switch (speedInterface.text)
        {
            case "1x":
                speedInterface.text = isSpeedUp ? "2x" : "1x";
                break;
            case "2x":
                speedInterface.text = isSpeedUp ? "4x" : "1x";
                break;
            case "4x":
                speedInterface.text = isSpeedUp ? "8x" : "2x";
                break;
            case "8x":
                speedInterface.text = isSpeedUp ? "16x" : "4x";
                break;
            case "16x":
                speedInterface.text = isSpeedUp ? "16x" : "8x";
                break;
        }
    }
}
