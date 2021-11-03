using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;
public class GameManager : MonoBehaviour
{

    public GameObject latestGazeObject;
    public PlayerMovement player;
    public MouseLook playerEye;
    public bool moveTwoPlayer = false;
    public Vector3 TargetPos;
    public GameObject AI;
    public float distanceOffset = 10;
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
                playerEye.limitRotate = true;
                AI = latestGazeObject;
                TargetPos = (AI.transform.position + player.transform.position) / 2;
                moveTwoPlayer = true;
                //print("gaze");
            }
        }
        if (moveTwoPlayer)
        {
            if (Vector3.Distance(player.transform.position, AI.transform.position) > distanceOffset)
            {
                AI.transform.position = Vector3.Lerp(AI.transform.position, TargetPos, 0.002f);
                player.transform.position = Vector3.Lerp(player.transform.position, TargetPos, 0.002f);
            }
            
            //print(Vector3.Distance(player.transform.position, AI.transform.position));
            if (Vector3.Distance(player.transform.position, AI.transform.position) < distanceOffset)
            {
                moveTwoPlayer = false;
            }
        }
    }

}
