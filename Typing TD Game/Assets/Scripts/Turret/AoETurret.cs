using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AoETurret : MonoBehaviour
{
    [SerializeField] private float attackRadius;
    [SerializeField] private float damage;
    [SerializeField] private float startSpeed;
    [SerializeField] private float slowSpeed;
    [SerializeField] private GameObject impactFX;
    [SerializeField] private GameObject AoEFX;
    GameManager gm;
    // private int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.instance;
        InvokeRepeating("CheckForEnemy",1.0f,1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CheckForEnemy()
    {
        // enemyCount = 0;
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
        }

        Collider[] colliders = Physics.OverlapSphere(transform.position,attackRadius);

        foreach(Collider c in colliders)
        {
            if(c.CompareTag("Enemy") && gm.ManaCount > 0)
            {
                gm.DecreaseMana();
                // enemyCount++;
                // Debug.Log("Enemy Count : "+enemyCount);
                StartCoroutine(CastEffect(0.9f));
                HitTarget(c.transform);
            }
        }
    }

    void HitTarget(Transform target)
    {
        GameObject effects = (GameObject) Instantiate(impactFX,target.transform.position,Quaternion.Euler(90,0,0));

        Destroy(effects,2.0f);

        //Slow The Enemy And Damage The Enemy
        target.GetComponent<NavMeshAgent>().speed = slowSpeed;
        target.GetComponent<NavMeshAgent>().acceleration = slowSpeed;
        Damage(target);
    }

    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if(e != null)
        {
            e.TakeDamage(damage);
        }
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
