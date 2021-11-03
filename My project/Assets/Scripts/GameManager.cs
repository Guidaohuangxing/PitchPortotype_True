using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;
public class GameManager : MonoBehaviour
{

    public GameObject latestGazeObject;
    public PlayerMovement player;
    public MouseLook playerEye;
    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }
    // Update is called once per frame
    void Update()
    {
        if(playerEye.GetFocusedObject() != null)
        {
            latestGazeObject = playerEye.GetFocusedObject();
        }
        if(latestGazeObject != null && latestGazeObject.tag == "Player")
        {
            if (latestGazeObject.GetComponent<FakeAI>().LookAtPlayer())
            {
                player.canMove = false;
                //print("gaze");
            }
        }
    }

}
