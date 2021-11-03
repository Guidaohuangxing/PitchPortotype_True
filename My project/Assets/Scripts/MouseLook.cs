using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = .001f;

    public Transform playerBody;

    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        //float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        GazePoint gazePoint = TobiiAPI.GetGazePoint();
        if (gazePoint.IsRecent())
        {
            float mouseX = (gazePoint.Viewport.x - 0.5f) * 2 * mouseSensitivity;
            float mouseY = (gazePoint.Viewport.y - 0.5f) * 2 * mouseSensitivity;
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            print(xRotation);
            transform.localRotation = Quaternion.Euler(xRotation, 0, 0f);
            playerBody.Rotate(Vector3.up * mouseX);

        }
       

        
        
    }
}
