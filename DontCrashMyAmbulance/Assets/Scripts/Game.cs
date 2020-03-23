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
    
    public void StartGame()
    {
        accelerateButton.gameObject.SetActive(true);
        brakeButton.gameObject.SetActive(true);
        startButton.gameObject.SetActive(false);
        ambulance.Initialize(initialAmbulanceDirection);
    }

    public void EndGame()
    {
        FindObjectOfType<SceneLoader>().LoadEndScene();
    }
}
