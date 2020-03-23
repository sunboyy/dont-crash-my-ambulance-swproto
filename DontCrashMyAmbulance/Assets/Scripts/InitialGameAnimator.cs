using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitialGameAnimator : MonoBehaviour
{
    [SerializeField] float animationTimer;
    [SerializeField] Button startButton;

    bool isStarted = false;

    // Update is called once per frame
    void Update()
    {
        if (!isStarted)
        {
            FindObjectOfType<Game>().SetSpeed(10f);
            isStarted = true;
        }
        animationTimer -= Time.deltaTime;
        if (animationTimer <= 0)
        {
            FindObjectOfType<Game>().SetSpeed(1f);
            startButton.gameObject.SetActive(true);
            Destroy(gameObject);
        }
    }
}
