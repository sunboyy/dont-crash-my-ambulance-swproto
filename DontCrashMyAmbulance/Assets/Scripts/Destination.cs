﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Ambulance>())
        {
            FindObjectOfType<Game>().EndGame(true);
        }
    }
}
