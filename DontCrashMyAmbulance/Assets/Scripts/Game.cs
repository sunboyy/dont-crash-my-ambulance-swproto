using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] Button startButton;
    [SerializeField] Button accelerateButton;
    [SerializeField] Button brakeButton;
    [SerializeField] Text speedText;
    [SerializeField] Vehicle ambulance;
    [SerializeField] Direction initialAmbulanceDirection;
    [SerializeField] TrafficStart trafficStart;

    readonly float roadSize = 1.28f;
    readonly float baseVelocity = 0.256f;
    float currentSpeed = 1;
    readonly List<Vehicle> activeVehicles = new List<Vehicle>();

    public void StartGame()
    {
        AddActiveVehicle(ambulance);
        accelerateButton.gameObject.SetActive(true);
        brakeButton.gameObject.SetActive(true);
        startButton.gameObject.SetActive(false);
        ambulance.Initialize(initialAmbulanceDirection, baseVelocity);
    }

    public void EndGame()
    {
        FindObjectOfType<SceneLoader>().LoadEndScene();
    }

    public void AddActiveVehicle(Vehicle vehicle)
    {
        activeVehicles.Add(vehicle);
    }

    public void RemoveActiveVehicle(Vehicle vehicle)
    {
        activeVehicles.Remove(vehicle);
    }

    public float GetCurrentVelocity()
    {
        return baseVelocity * Mathf.Pow(2, currentSpeed - 1);
    }

    public void SpeedUp()
    {
        currentSpeed++;
        if (currentSpeed > 3)
        {
            currentSpeed = 3;
        }
        UpdateGameSpeed();
    }

    public void SpeedDown()
    {
        currentSpeed--;
        if (currentSpeed < 1)
        {
            currentSpeed = 1;
        }
        UpdateGameSpeed();
    }

    void UpdateGameSpeed()
    {
        float speedMultiplier = Mathf.Pow(2, currentSpeed - 1);
        float newVelocity = baseVelocity * speedMultiplier;
        foreach (Vehicle v in activeVehicles)
        {
            v.SetSpeed(newVelocity);
        }
        trafficStart.SetSpawnInterval(roadSize / newVelocity);
        speedText.text = string.Format("Speed: {0}x", speedMultiplier);
    }
}
