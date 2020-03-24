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

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(string.Format("Level{0}", level));
    }

    public void LoadEndScene()
    {
        Debug.Log(Game.isWin);
        SceneManager.LoadScene("EndScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
