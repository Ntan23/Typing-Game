using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AoETurret : MonoBehaviour
{
    [SerializeField] private float attackRadius;
    [SerializeField] private float damage;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private float startSpeed;
    [SerializeField] private float slowSpeed;
    [SerializeField] private GameObject impactFX;
    [SerializeField] private GameObject AoEFX;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CheckForEnemy",0.0f,1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CheckForEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            if(enemy == null)
            {
                return;
            }

            float enemyDistance = Vector3.Distance(transform.position,enemy.transform.position);
            
            if(enemyDistance >= attackRadius)
            {
                enemy.GetComponent<NavMeshAgent>().speed = startSpeed;
                enemy.GetComponent<NavMeshAgent>().acceleration = startSpeed;
            }
            else if(enemyDistance <= attackRadius+5)
            {
                StartCoroutine(CastEffect(0.8f));
            }
        }

        Collider[] colliders = Physics.OverlapSphere(transform.position,attackRadius,enemyLayer);

        foreach(Collider c in colliders)
        {
            if(c.CompareTag("Enemy"))
            {
                HitTarget(c.transform);
                Debug.Log("Enemy Targeted");
            }
        }
    }

    void HitTarget(Transform target)
    {
        GameObject effects = (GameObject) Instantiate(impactFX,target.transform.position,Quaternion.Euler(90,0,0));

        Destroy(effects,2.0f);

        //Slow The Enemy
        target.GetComponent<NavMeshAgent>().speed = slowSpeed;
        target.GetComponent<NavMeshAgent>().acceleration = slowSpeed;
        target.GetComponent<Enemy>().TakeDamage(damage);
    }

    IEnumerator CastEffect(float waitTime)
    {
        AoEFX.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        AoEFX.SetActive(false);
    }

    private void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position,attackRadius); 
    }   
}
