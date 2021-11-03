using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RealisticEyeMovements;
public class FakeAI : MonoBehaviour
{
    [SerializeField]
    Transform sphereXform;
    public LookTargetController lookTargetController;
    public bool isRotation = false;
    public Transform player;
    public Vector3 targetDir;
    public float rotateThershold = 20f;
    // Start is called before the first frame update
    void Start()
    {
        lookTargetController = FindObjectOfType<LookTargetController>();
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        if (isRotation)
        {
            //if(Vector3.Angle(targetDir, transform.forward) > rotateThershold)
            //{
            //    Vector3 now = Vector3.Lerp(transform.forward, targetDir, 0.02f);
            //    this.transform.LookAt(now, Vector3.up);
            //    print(this.transform.position);
            //    print(targetDir);
            //}
            //else
            //{
            //    isRotation = false;
            //}
            Vector3 now = Vector3.Lerp(transform.forward, targetDir, 0.02f);
            this.transform.LookAt(now, Vector3.up);
            print(this.transform.position);
            print(targetDir);
        }
    }
    public void LookAtEyeball()
    {
        lookTargetController.LookAtPoiDirectly(sphereXform);
    }

    public bool LookAtPlayer()
    {
        print("看到了!");
        isRotation = true;
        targetDir = player.position - this.transform.position;
        lookTargetController.LookAtPlayer();
        return true;
    }
}
