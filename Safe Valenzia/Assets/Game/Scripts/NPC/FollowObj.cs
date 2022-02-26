using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObj : MonoBehaviour
{
    
    [SerializeField] private Transform obj;

    private void Update()
    {
        transform.position = obj.position;
    }

}
