using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool isGrounded = true;
    public LayerMask ground;

    private void OnTriggerStay(Collider collision)
    {
        Debug.Log("trigger");
        if (collision.gameObject.layer == 3)
        {
            isGrounded = true;
            Debug.Log("b");
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.layer == 3)
        {
            isGrounded = false;
            Debug.Log("a");
        }
    }
}
