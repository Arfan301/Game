using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float _moveSpeed;

    public float _groundDrag;

    [Header("Ground Check")]
    public float _playerHeight;
    public LayerMask _whatIsGround;
    bool _grounded;
    public Transform _orientation;
    private Rigidbody rb;
    private Vector3 move;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // sensor to detect ground
        _grounded = Physics.Raycast(transform.position, Vector3.down, _playerHeight * 0.5f + 0.2f, _whatIsGround);

        // Movement section
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        move = _orientation.forward * vertical + _orientation.right * horizontal;
        rb.AddForce(move.normalized * _moveSpeed * 10f, ForceMode.Force);

        //handle drag
        if (_grounded){
            rb.drag = _groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
    }
}
