using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotate : MonoBehaviour
{

    [SerializeField] private float waitTime = 2f;
    [SerializeField] private float turnAngle = -90f;
    [SerializeField] private float timeToTurn = 3f;
    [SerializeField] private int ticks = 100;
    [SerializeField] private GameObject[] Lights;

    private bool isSpinning = false;

    void Start()
    {
        Lights[1].SetActive(false);
        Lights[0].SetActive(true);
    }

    public void TriggerWheel()
    {
        TurnWheel(turnAngle, timeToTurn, ticks);
    }
    
    public void TurnWheel(float angle, float timeToTurn, int ticks)
    {
        if(isSpinning)
         return;
        
        isSpinning = true;
        float tickTime = timeToTurn / ticks;

        StartCoroutine(RealTurn(angle, tickTime, ticks));
    }

    private IEnumerator RealTurn(float angle, float tickTime, int ticks)
    {
        Lights[0].SetActive(false);
        Lights[1].SetActive(true);
        yield return new WaitForSeconds(waitTime);
        for(int i = 0; i < ticks; i++)
        {
            transform.Rotate(new Vector3(0, 0, angle / ticks));
            yield return new WaitForSeconds(tickTime);
        }
        Lights[1].SetActive(false);
        Lights[0].SetActive(true);
        isSpinning = false;
    }

}
