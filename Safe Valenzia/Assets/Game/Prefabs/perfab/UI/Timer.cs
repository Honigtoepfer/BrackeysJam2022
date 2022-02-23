using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    public Text CurrentTimeText;
    float CurrentTime;
    public int startMinute;
    // Start is called before the first frame update
    void Start()
    {
        CurrentTime = startMinute * 60;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (CurrentTime > 0.001)
        {
            CurrentTime = CurrentTime - Time.deltaTime;
        }
        TimeSpan time = TimeSpan.FromSeconds(CurrentTime);
        CurrentTimeText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();
    }
}
