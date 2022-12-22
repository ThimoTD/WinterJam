using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public static float mouseSensitivity = 200f;

    public Transform playerBody;

    float xRotation = 0f;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        float MouseX = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity;
        float MouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity;

        xRotation -= MouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * MouseX);
    }
}

