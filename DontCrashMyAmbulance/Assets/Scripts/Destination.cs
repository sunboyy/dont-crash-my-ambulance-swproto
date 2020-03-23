using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination : MonoBehaviour
{
    [SerializeField] Game game;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Ambulance>())
        {
            Game.isWin = true;
            game.EndGame();
        }
    }
}
