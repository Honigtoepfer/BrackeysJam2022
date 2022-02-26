using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMnue : MonoBehaviour
{
    public Slider volumeSlider;
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
         Application.Quit();
         Debug.Log("Game Exit !");
    }
    //*****OPTIONS SETTINGS****************
    public void Back()
    {
        SceneManager.LoadScene(0);
    }
    public void VolumeContriller(){
        AudioListener.volume =volumeSlider.value;
    }
}
