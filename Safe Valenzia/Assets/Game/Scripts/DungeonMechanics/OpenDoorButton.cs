using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorButton : MonoBehaviour, IInteractable
{
    
    [SerializeField] private GameObject obj;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private GameObject[] Lights;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float wait = 1f;
    [SerializeField] private bool reverse = false;
    [HideInInspector] public bool pressed = false;

    public void Interact()
    {
        if(pressed)
            return;
        
        if(!reverse)
            obj.SetActive(false);
        else
            obj.SetActive(true);

        StartCoroutine(graphic());
    }

    void Start()
    {
        spriteRenderer.sprite = sprites[0];
        Lights[2].SetActive(false);
        Lights[1].SetActive(true);
        Lights[0].SetActive(false);

        if(reverse)
            obj.SetActive(false);
        else
            obj.SetActive(true);

    }

    IEnumerator graphic()
    {
        pressed = true;

        spriteRenderer.sprite = sprites[1];
        Lights[1].SetActive(false);
        Lights[2].SetActive(true);

        yield return new WaitForSeconds(wait);
        spriteRenderer.sprite = sprites[0];
        Lights[2].SetActive(false);
        Lights[1].SetActive(true);

        if(reverse)
            obj.SetActive(false);
        else
            obj.SetActive(true);

        pressed = false;
    }

    public void Enter()
    {
        Lights[0].SetActive(true);
    }

    public void Exit()
    {
        Lights[0].SetActive(false);
    }
}
