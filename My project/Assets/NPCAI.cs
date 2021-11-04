using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NPCAI : MonoBehaviour
{
    NavMeshAgent nma;
    Vector3 targetPos;
    public float planeWidth = 5;
    public float planeLength = 5;
    public float reachThreshold = 0.5f;
    public GameObject debugCube;
    public float reTargetTime = .5f;
    private float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        nma = this.GetComponent<NavMeshAgent>();
        targetPos = new Vector3(Random.Range(-1f, 1f) * planeWidth, 0, Random.Range(-1f, 1f) * planeLength);
        if (debugCube)
        {
            Instantiate(debugCube, targetPos, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(this.transform.position, targetPos) > reachThreshold)
        {
            nma.destination = targetPos;
        }
        else
        {
            targetPos = new Vector3(Random.Range(-1f, 1f) * planeWidth, 0, Random.Range(-1f, 1f) * planeLength);
            if (debugCube)
            {
                Instantiate(debugCube, targetPos, Quaternion.identity);
            }
        }
        //print(nma.velocity);
        if(nma.velocity.magnitude == 0)
        {
            time += Time.deltaTime;
            if(time > reTargetTime)
            {
                targetPos = new Vector3(Random.Range(-1f, 1f) * planeWidth, 0, Random.Range(-1f, 1f) * planeLength);
            }
        }
    }
}
