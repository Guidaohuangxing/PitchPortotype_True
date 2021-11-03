using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = .001f;

    public Transform playerBody;

    float xRotation = 0f;
    public Canvas canvas;//use to get the screen width and length

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (true)//GetComponentInParent<PlayerMovement>().canMove)
        {
            GazePoint gazePoint = TobiiAPI.GetGazePoint();
            if (gazePoint.IsRecent())
            {
                float mouseX = (gazePoint.Viewport.x - 0.5f) * 2 * mouseSensitivity;
                float mouseY = (gazePoint.Viewport.y - 0.5f) * 2 * mouseSensitivity;
                xRotation -= mouseY;
                xRotation = Mathf.Clamp(xRotation, -90f, 90f);
                //print(xRotation);
                transform.localRotation = Quaternion.Euler(xRotation, 0, 0f);
                playerBody.Rotate(Vector3.up * mouseX);

            }
        }
        //GetFocusedObject();


    }



    public GameObject GetFocusedObject()
    {
        GazePoint gazePoint = TobiiAPI.GetGazePoint();
        if (gazePoint.IsRecent())
        {
            Vector2 viewPortEyePos = gazePoint.Viewport;// - new Vector2(0.5f, 0.5f);
            Vector3 eyePos = viewPortEyePos * new Vector2(canvas.renderingDisplaySize.x / canvas.scaleFactor, canvas.renderingDisplaySize.y / canvas.scaleFactor);
            //print("eyepos" + eyePos);
            //print("mousePos" + Input.mousePosition);
            Ray ray = Camera.main.ScreenPointToRay(eyePos);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000))
            {
                //print(hit.collider.name);
                return hit.collider.gameObject;

            }
           
        }
        return null;
    }
}
