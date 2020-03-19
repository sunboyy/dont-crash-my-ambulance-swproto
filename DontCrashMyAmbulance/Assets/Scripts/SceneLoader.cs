using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void LoadEndScene()
    {
        SceneManager.LoadScene("EndScene");
    }
}
