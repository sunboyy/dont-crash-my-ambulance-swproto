using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScene : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Text status;
    void Start()
    {
        if (Game.isWin)
        {
            status.text = "You Win!";
        }
        else
        {
            status.text = "You Lose!";
        }
    }
}
