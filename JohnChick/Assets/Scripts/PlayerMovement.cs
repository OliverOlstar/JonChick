using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float maxSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;

    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 moveInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveInput = moveInput.normalized * moveSpeed * Time.deltaTime;

        if (_rb.velocity.magnitude < maxSpeed)
            _rb.AddForce(moveInput, ForceMode.VelocityChange);

        if (Input.GetButtonDown("Jump"))
            _rb.AddForce(Vector3.up * jumpForce);
    }
}
