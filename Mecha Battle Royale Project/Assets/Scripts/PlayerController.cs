using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Movement : MonoBehaviour
{
    private Rigidbody _rb;

    [Header("Movement")]
    public float _moveSpeed = 5f;
    public float _jumpForce = 5.0f;

    [Header("Camera")]
    public Cinemachine.AxisState xAxis;
    public Cinemachine.AxisState yAxis;
    
    [SerializeField] Transform camFollowPos;

    [Header("Aim")]
    public CinemachineVirtualCamera aimVCam;
    
    [Header("Cross Hair")]
    public Canvas thirdPersonCanvas;
    public Canvas aimCanvas;

    private int priorityBoost = 10;
    bool _isAiming = false;

    // [Header("Gun pick ups")]
    // public Transform gunPosition;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        move();
        CameraRotation();
        Aiming();
    }

    void move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        _rb.MovePosition(_rb.position + move * _moveSpeed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && Mathf.Abs(_rb.velocity.y) < 0.001f)
        {
            _rb.AddForce(new Vector3(0, _jumpForce,0), ForceMode.Impulse);
        }

    }
    
    void CameraRotation()
    {
        xAxis.Update(Time.deltaTime);
        yAxis.Update(Time.deltaTime);
    }

    void LateUpdate()
    {
        camFollowPos.localEulerAngles = new Vector3(yAxis.Value, camFollowPos.localEulerAngles.y, camFollowPos.localEulerAngles.z);
        transform.eulerAngles = new Vector3(0, xAxis.Value, 0);
    }

    void Aiming()
    {
        if (Input.GetMouseButtonDown(1)  && !_isAiming)
        {
            aimVCam.Priority += priorityBoost;
            thirdPersonCanvas.enabled = false;
            aimCanvas.enabled = true;
            _isAiming = true;
        }
        else if (Input.GetMouseButtonDown(1)  && _isAiming)
        {
            aimVCam.Priority -= priorityBoost;
            thirdPersonCanvas.enabled = true;
            aimCanvas.enabled = false;
            _isAiming = false;
        }
    }

}
