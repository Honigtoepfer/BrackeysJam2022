using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimHandler : MonoBehaviour
{
    
    MainInput mainInput;
    [SerializeField] private Animator anim;

    private void Awake()
    {
        mainInput = new MainInput();
        anim.SetFloat("x", 0);
        anim.SetFloat("y", -1);
    }

    private void Update()
    {
        Vector2 dirToMove = mainInput.Player.move.ReadValue<Vector2>();
        if(dirToMove.magnitude > .3f)
        {
            anim.SetFloat("x", dirToMove.x);
            anim.SetFloat("y", dirToMove.y);
    	    anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        
    }

    void OnEnable()
    {
        mainInput.Enable();
    }

    void OnDisable()
    {
        mainInput.Disable();
    }

}
