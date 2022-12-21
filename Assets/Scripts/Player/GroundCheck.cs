using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool isGrounded = true;
    public LayerMask ground;

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.layer == 3) isGrounded = true;
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.layer == 3) isGrounded = false;
    }
}
