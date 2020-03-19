using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] Button startButton;
    [SerializeField] Button accelerateButton;
    [SerializeField] Button brakeButton;
    [SerializeField] Ambulance ambulance;
    [SerializeField] SceneLoader sceneLoader;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        accelerateButton.gameObject.SetActive(true);
        brakeButton.gameObject.SetActive(true);
        startButton.gameObject.SetActive(false);
        ambulance.ChangeDirection(Direction.Right);
    }

    public void EndGame()
    {
        sceneLoader.LoadEndScene();
    }
}
