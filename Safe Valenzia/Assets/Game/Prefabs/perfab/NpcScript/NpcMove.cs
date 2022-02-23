using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcMove : MonoBehaviour , IInteractable
{
    [SerializeField]
    Vector3 NpcDirectionVector;
    public Transform NpcTransform;
    public float NpcSpeed = 1f;
    Rigidbody2D NpcRigidbody;
    public Animator NpcAnimator;
    public Collider2D NpcBounds;
    public bool PlayerInRange = false;
    // Start is called before the first frame update
    void Start()
    {
       
        NpcTransform = GetComponent<Transform>();
        NpcRigidbody = GetComponent<Rigidbody2D>();
        NpcAnimator = GetComponent<Animator>();
        ChaneDirection();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerInRange == false)
        {
            Move();
        }
            
    }
    //****************************************
    void Move()
    {
        Vector3 temp = NpcTransform.position + NpcDirectionVector * NpcSpeed * Time.deltaTime;
        if (NpcBounds.bounds.Contains(temp))
        {
            NpcRigidbody.MovePosition(temp);
           // Debug.Log("in!!");

        }
        else
        {
            ChaneDirection();
            //Debug.Log("out!!");
        }
    }
    //****************************************
    void StopMoving()
    {

    }
    //****************************************
    void ChaneDirection()
    {
        int direction = Random.Range(0, 4);
        switch (direction)
        {
            case 0:
                //walking to the right..
                NpcDirectionVector = Vector3.right;
                break;
            case 1:
                //walikng up...
                NpcDirectionVector = Vector3.up;
                break;
            case 2:
                //walking left...
                NpcDirectionVector = Vector3.left;
                break;
            case 3:
                //walking down...
                NpcDirectionVector = Vector3.down;
                break;
            default:
                break;
            
        }
        NpcAnimation();
    }
    //**********************
    void NpcAnimation()
    {
        NpcAnimator.SetFloat("WalkingX", NpcDirectionVector.x);
        NpcAnimator.SetFloat("WalkingY", NpcDirectionVector.y);
    }
    //**************************
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector3 temp1 = NpcDirectionVector;
        int loops = 0;
        while(temp1 == NpcDirectionVector && loops<100)
        {
            ChaneDirection();
            loops++;
        }
    }
    //***************interactable************
    void IInteractable.Interact()
    {
        // do nothing...
    }
    // to sop walking when inter acting with the player..
    void IInteractable.Enter()
    {
        PlayerInRange = true;
    }
    //to start moving again when the player is out of area ...
    void IInteractable.Exit()
    {
        PlayerInRange = false;
    }
    //****************************************

}
