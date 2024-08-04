using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class MechaHandler : MonoBehaviour
{
    [Header("VCam")]
    public CinemachineVirtualCamera mechaVCam;

    [Header("GameObjects")]
    public GameObject playerObject;
    public GameObject mechaObject;

    private int addPriority = 10;
    bool isInMecha;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CallMecha();
    }

    void CallMecha()
    {
        if(Input.GetKeyDown(KeyCode.E) && !isInMecha)
        {
            playerObject.SetActive(false);
            mechaObject.SetActive(true);
            mechaVCam.Priority += addPriority;
            isInMecha = true;
        }
        else if(Input.GetKeyDown(KeyCode.E) && isInMecha)
        {
            playerObject.SetActive(true);
            mechaObject.SetActive(false);
            mechaVCam.Priority -= addPriority;
            isInMecha = false;
        }
    }
}
