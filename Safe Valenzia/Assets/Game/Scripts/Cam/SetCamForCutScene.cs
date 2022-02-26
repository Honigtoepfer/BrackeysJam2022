using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


public class SetCamForCutScene : MonoBehaviour
{
    
    [SerializeField] private CameraFollower cam;
    [SerializeField] private Transform CamTarget;
    [SerializeField] private Volume first;
    [SerializeField] private float firstTarget = 1f;

    public void SetCamTarget()
    {
        cam.followObj = CamTarget;
    }

    public void SetCamTargetFOV(float fov)
    {
        cam.TargetFOV = fov;
    }

    void Update()
    {
        first.weight = Mathf.Lerp(first.weight, firstTarget, Time.deltaTime);
    }



}
