using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateGObyOKey : MonoBehaviour
{
    
    [SerializeField] private GameObject key;
    [SerializeField] private GameObject obj;
    [SerializeField] private GameObject[] Lights;
    [SerializeField] private bool reverse = false;
    [SerializeField] private OpenDoorButton openDoorButton;

    void Start()
    {
        Lights[1].SetActive(false);
        Lights[0].SetActive(true);
        if(!reverse)
        {
            obj.SetActive(true);
        }
        else
        {
            obj.SetActive(false);
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject == key)
        {
            Lights[0].SetActive(false);
            Lights[1].SetActive(true);

            if(openDoorButton != null)
                if(openDoorButton.pressed)
                    return;
            if(!reverse)
                obj.SetActive(false);
            else
                obj.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject == key)
        {
            Lights[1].SetActive(false);
            Lights[0].SetActive(true);

            if(openDoorButton != null)
                if(openDoorButton.pressed)
                    return;
            if(!reverse)
                obj.SetActive(true);
            else
                obj.SetActive(false);
        }
    }

}
