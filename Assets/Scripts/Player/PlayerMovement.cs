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

    public GameObject GroundObject;
    private GroundCheck gc;

    public int dash;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gc = GroundObject.GetComponent<GroundCheck>();
    }

    private void FixedUpdate()
    {
        Movement(MyInput());
    }

    void Update()
    {
        speedcheck();
        if (Input.GetKeyDown(KeyCode.Space) && ReadyToJump()) Jump();

        if (Input.GetKeyDown(KeyCode.LeftControl)) Dash();
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
            rb.drag = 1;
            rb.AddForce(0.2f * moveSpeed / Time.deltaTime * moveDirection.normalized, ForceMode.Force);

            if (input == new Vector2(0, 0))
            {
                rb.velocity = new Vector3(Mathf.Lerp(rb.velocity.x, 0 , 0.003f), 0, Mathf.Lerp(rb.velocity.z, 0, 0.003f));

            }
        }


        if (!IsGrounded())
        {
            rb.drag = 0;
            rb.AddForce(0.02f * moveSpeed / Time.deltaTime * moveDirection.normalized, ForceMode.Force);
        }

    }

    private void speedcheck()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

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

    private void Dash()
    {
        Debug.Log("a");
        rb.AddForce(transform.forward * dash, ForceMode.Impulse);
    }

    private Vector2 MyInput() => new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

    private bool IsGrounded() => gc.isGrounded;

}