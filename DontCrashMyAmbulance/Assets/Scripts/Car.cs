using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Ambulance>())
        {
            Game.isWin = false;
            FindObjectOfType<SceneLoader>().LoadEndScene();
        }
    }
}