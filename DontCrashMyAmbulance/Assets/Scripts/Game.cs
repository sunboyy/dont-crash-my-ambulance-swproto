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
    static public bool isWin = false;

    public void StartGame()
    {
        hasStarted = true;
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
        else if (speed > 6)
        {
            currentSpeed = 6;
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
        Time.timeScale = speedMultiplier;
        speedText.text = string.Format("Speed: {0}x", speedMultiplier);
    }
}
