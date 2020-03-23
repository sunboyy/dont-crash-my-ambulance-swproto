using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitialGameAnimator : MonoBehaviour
{
    [SerializeField] float animationTimer;
    [SerializeField] Button startButton;

    private void Start()
    {
        FindObjectOfType<Game>().SetSpeed(10f);
    }

    // Update is called once per frame
    void Update()
    {
        animationTimer -= Time.deltaTime;
        if (animationTimer <= 0)
        {
            FindObjectOfType<Game>().SetSpeed(1f);
            startButton.gameObject.SetActive(true);
            Destroy(gameObject);
        }
    }
}
