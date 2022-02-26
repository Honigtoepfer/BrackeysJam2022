using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text CurrentTimeText;
    public int startMinute;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
        if (GameVars.current.currentTimer > 0.001)
        {
            GameVars.current.currentTimer -= Time.deltaTime;
        }
        TimeSpan time = TimeSpan.FromSeconds(GameVars.current.currentTimer);
        CurrentTimeText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();
        if (GameVars.current.currentTimer <= 0)
        {
            GameVars.current.currentTimer = 0;
        }
    }
}
