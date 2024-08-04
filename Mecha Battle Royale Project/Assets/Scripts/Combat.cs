using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class AimManager : MonoBehaviour
{
    [Header("Camera")]
    public CinemachineVirtualCamera aimVCam;
    
    [Header("canvas")]
    public Canvas ThirdPersonCanvas;
    public Canvas aimCanvas;

    private int priorityBoost = 10;
    bool _isAiming = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Aiming();
    }

    void Aiming()
    {
        if (Input.GetMouseButtonDown(1)  && !_isAiming)
        {
            aimVCam.Priority += priorityBoost;
            ThirdPersonCanvas.enabled = false;
            aimCanvas.enabled = true;
            _isAiming = true;
        }
        else if (Input.GetMouseButtonDown(1)  && _isAiming)
        {
            aimVCam.Priority -= priorityBoost;
            ThirdPersonCanvas.enabled = true;
            aimCanvas.enabled = false;
            _isAiming = false;
        }
    }
}
