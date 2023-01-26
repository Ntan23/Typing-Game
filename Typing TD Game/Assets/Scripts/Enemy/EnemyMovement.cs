using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    // public Vector3 destinationPoint;
    GameManager gm;
    public ShakeDamage shakeDamage;

    AudioManager am;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.instance;
        shakeDamage = FindObjectOfType<ShakeDamage>();
        am= AudioManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        // if(this.gameObject.transform.position.x == destinationPoint.x && this.gameObject.transform.position.z == destinationPoint.z)
        // {
        //     return;
        // }
        
        // if(this.gameObject.transform.position.x < destinationPoint.x && this.gameObject.transform.position.z < destinationPoint.z)
        // {
        //     agent.SetDestination(destinationPoint);
        // }
        // else
        // {
        //     return;
        // }

        agent.SetDestination(gm.destinationPoint);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("EndPos"))
        {
            EndPath();
        }
    }

    void EndPath()
    {
        am.PlayAudioShot("EnemyAttack");
        gm.HitDamage();
        WaveSpawner.enemiesAlive--;
        shakeDamage.isDmged = true;
        Destroy(this.gameObject);
    }
}
