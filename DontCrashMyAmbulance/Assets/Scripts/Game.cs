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

    readonly float roadSize = 1.28f;
    readonly float baseVelocity = 0.256f;
    bool hasStarted = false;
    float currentSpeed = 1;
    readonly List<Vehicle> activeVehicles = new List<Vehicle>();
    readonly List<TrafficStart> trafficStarts = new List<TrafficStart>();
    static public bool isWin = false;

    public void StartGame()
    {
        hasStarted = true;
        AddActiveVehicle(ambulance);
        accelerateButton.gameObject.SetActive(true);
        brakeButton.gameObject.SetActive(true);
        startButton.gameObject.SetActive(false);
        ambulance.Initialize(initialAmbulanceDirection, GetCurrentVelocity());
    }

    public void EndGame(bool isWin)
    {
        Game.isWin = isWin;
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

    public void RegisterTraffic(TrafficStart trafficStart)
    {
        trafficStarts.Add(trafficStart);
    }

    public bool HasStarted()
    {
        return hasStarted;
    }

    public float GetCurrentVelocity()
    {
        return baseVelocity * Mathf.Pow(2, currentSpeed - 1);
    }

    public void SpeedUp()
    {
        SetSpeed(currentSpeed + 1);
    }

    public void SpeedDown()
    {
        SetSpeed(currentSpeed - 1);
    }

    public void SetSpeed(float speed)
    {
        if (speed < 1)
        {
            currentSpeed = 1;
        }
        else if (speed > 5)
        {
            currentSpeed = 5;
        }
        else
        {
            currentSpeed = speed;
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
        foreach (TrafficStart trafficStart in trafficStarts)
        {
            trafficStart.SetSpawnInterval(roadSize / newVelocity);
        }
        speedText.text = string.Format("Speed: {0}x", speedMultiplier);
    }
}
