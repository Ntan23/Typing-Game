using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public Vector3 destinationPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.transform.position.x >= destinationPoint.x && this.gameObject.transform.position.y >= destinationPoint.y && this.gameObject.transform.position.z >= destinationPoint.z)
        {
            return;
        }
        
        if(this.gameObject.transform.position.x < destinationPoint.x && this.gameObject.transform.position.y < destinationPoint.y && this.gameObject.transform.position.z < destinationPoint.z)
        {
            agent.SetDestination(destinationPoint);
        }
    }
}
