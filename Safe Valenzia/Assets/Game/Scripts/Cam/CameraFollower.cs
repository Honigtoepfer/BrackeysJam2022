using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    
    MainInput mainInput;
    [SerializeField] private Transform followObj;
    [SerializeField] private float extendLength = 1f;
    [SerializeField] private float speed = 1f;

    void Awake()
    {
        mainInput = new MainInput();
    }

    private void LateUpdate()
    {
        if(followObj == null)
            return;
        Vector2 dirToMove = mainInput.Player.move.ReadValue<Vector2>().normalized * extendLength;
        dirToMove += (Vector2)followObj.position;
        dirToMove = Vector2.Lerp(transform.position, dirToMove, Time.deltaTime * speed);
        
        transform.position = new Vector3(dirToMove.x, dirToMove.y, -10);

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
