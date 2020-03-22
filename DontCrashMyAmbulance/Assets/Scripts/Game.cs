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
    [SerializeField] Direction initialAmbulanceDirection;
    [SerializeField] Car car;
    
    public float Timer = 2;
    Car carClone;

    // Update is called once per frame
    void Update()
    {
        if (carClone != null)
        {
            carClone.ChangeDirection(Direction.Down);
        }
        Timer -= Time.deltaTime;
        if (Timer <= 0)
        {
            GameObject clone;
            clone = Instantiate(car.gameObject);
            clone.transform.position = new Vector3(clone.transform.position.x, clone.transform.position.y, -5);
            carClone = (Car)clone.gameObject.GetComponent<Car>();
            Timer = 3;
        }
    }

    public void StartGame()
    {
        accelerateButton.gameObject.SetActive(true);
        brakeButton.gameObject.SetActive(true);
        startButton.gameObject.SetActive(false);
        ambulance.ChangeDirection(initialAmbulanceDirection);
    }

    public void EndGame()
    {
        FindObjectOfType<SceneLoader>().LoadEndScene();
    }
}
