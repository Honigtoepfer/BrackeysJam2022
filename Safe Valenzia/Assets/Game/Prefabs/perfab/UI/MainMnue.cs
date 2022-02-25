using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMnue : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void options()
    {
        SceneManager.LoadScene("options");
    }
    public void Exit()
    {
        //exit the game...
    }
    //*****OPTIONS SETTINGS****************
    public void Back()
    {
        SceneManager.LoadScene(0);
    }
}
