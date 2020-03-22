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
    [SerializeField] Car car;
    
    public float Timer = 2;
    Vehicle carClone;

    // Update is called once per frame
    void Update()
    {
        if (carClone != null)
        {
            carClone.UpdateVelocity();
        }
        Timer -= Time.deltaTime;
        if (Timer <= 0)
        {
            GameObject clone;
            clone = Instantiate(car.gameObject);
            clone.transform.position = new Vector3(clone.transform.position.x, clone.transform.position.y, -5);
            carClone = clone.gameObject.GetComponent<Vehicle>();
            Timer = 3;
        }
    }

    public void StartGame()
    {
        accelerateButton.gameObject.SetActive(true);
        brakeButton.gameObject.SetActive(true);
        startButton.gameObject.SetActive(false);
        ambulance.UpdateVelocity();
    }

    public void EndGame()
    {
        FindObjectOfType<SceneLoader>().LoadEndScene();
    }
}
