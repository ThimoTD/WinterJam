using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed;

    public float jumpForce;
    public int extrajumps;
    public int maxJumps;

    public LayerMask whatisGround;

    public Transform orientation;

    public Vector3 moveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Movement(MyInput());
    }

    void Update()
    {
        speedcheck();
        if (Input.GetKeyDown(KeyCode.Space) && ReadyToJump()) Jump();
    }

    private bool ReadyToJump()
    {
        rb.drag = 0;
        if (IsGrounded())
        {
            extrajumps = maxJumps;
            return true;
        }

        if (extrajumps > 0)
        {
            extrajumps--;
            return true;
        }

        return false;
    }

    private void Movement(Vector2 input)
    {
        moveDirection = orientation.forward * input.y + orientation.right * input.x;

        if (IsGrounded())
        {
            rb.drag = 3;
            rb.AddForce(0.2f * moveSpeed / Time.deltaTime * moveDirection.normalized, ForceMode.Force);
        }
            

        if (!IsGrounded())
        {
            rb.drag = 0;
            rb.AddForce(0.02f * moveSpeed / Time.deltaTime * moveDirection.normalized, ForceMode.Force);
        }
            
    }

    private void speedcheck()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x,0f, rb.velocity.z);

        if (flatVel.magnitude > moveSpeed)
        {

            Vector3 limtedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limtedVel.x, rb.velocity.y, limtedVel.z);
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 5f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private Vector2 MyInput() => new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

    private bool IsGrounded() => Physics.Raycast(transform.position, Vector3.down, 1.45f + 0.2f, whatisGround);
}