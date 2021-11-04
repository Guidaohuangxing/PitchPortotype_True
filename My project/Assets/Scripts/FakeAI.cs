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
    public bool rotateOnlyOnce = true;
    Vector3 now;
    Quaternion startRotate;
    Quaternion EndRoatate;
    float startTime;
    float rotateAngle;
    public float rotateSpeed = 15f;
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
            //now = Vector3.Lerp(now, targetDir, 0.2f);
            float a = (Time.time - startTime) / (rotateAngle / rotateSpeed);
            transform.localRotation = Quaternion.Slerp(startRotate, EndRoatate, a);
            print(EndRoatate);
            //this.transform.LookAt(targetDir, Vector3.up);
            print("朝向:"+this.transform.forward);
            print("目标朝向"+targetDir );
        }
    }
    public void LookAtEyeball()
    {
        lookTargetController.LookAtPoiDirectly(sphereXform);
    }

    public bool LookAtPlayer()
    {
        print("看到了!");
        if (rotateOnlyOnce)
        {
            isRotation = true;
            //now = transform.forward;
            targetDir = player.position - this.transform.position;
            //targetDir = targetDir;
            //targetDir = targetDir.normalized;
            rotateOnlyOnce = false;
            startTime = Time.time;
            startRotate = this.transform.localRotation;
            rotateAngle = Vector3.Angle(transform.forward, targetDir);
            
            if(Vector3.Cross(transform.forward, targetDir).y < 0)
            {
                rotateAngle = -rotateAngle;
            }
            print(rotateAngle);
            EndRoatate = Quaternion.AngleAxis(rotateAngle, Vector3.up) * startRotate;
        }
        lookTargetController.LookAtPlayer();
        return true;
    }
}
