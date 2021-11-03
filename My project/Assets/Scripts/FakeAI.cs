using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RealisticEyeMovements;
public class FakeAI : MonoBehaviour
{
    [SerializeField]
    Transform sphereXform;
    public LookTargetController lookTargetController;
    // Start is called before the first frame update
    void Start()
    {
        lookTargetController = FindObjectOfType<LookTargetController>();
    }

   
    public void LookAtEyeball()
    {
        lookTargetController.LookAtPoiDirectly(sphereXform);
    }

    public bool LookAtPlayer()
    {
        print("看到了!");
        lookTargetController.LookAtPlayer();
        return true;
    }
}
