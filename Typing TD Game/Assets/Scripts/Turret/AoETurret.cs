using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AoETurret : MonoBehaviour
{
    [SerializeField] private float attackRadius;
    [SerializeField] private float damage;
    [SerializeField] private int manaCost;
    [SerializeField] private float startSpeed;
    [SerializeField] private float slowSpeed;
    [SerializeField] private GameObject impactFX;
    [SerializeField] private GameObject AoEFX;
    public static bool getSlowed = false;
    GameManager gm;
    WaveSpawner waveSpawner;
    // private int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.instance;
        waveSpawner = FindObjectOfType<WaveSpawner>();
        InvokeRepeating("CheckForEnemy",1.0f,1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CheckForEnemy()
    {
        // enemyCount = 0;
        // GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // foreach (GameObject enemy in enemies)
        // {
        //     if(enemy == null)
        //     {
        //         return;
        //     }

        //     float enemyDistance = Vector3.Distance(transform.position,enemy.transform.position);
            
        //     if(enemyDistance >= attackRadius)
        //     {
        //         enemy.GetComponent<NavMeshAgent>().speed = startSpeed;
        //         enemy.GetComponent<NavMeshAgent>().acceleration = startSpeed;
        //     }
        // }

        Collider[] colliders = Physics.OverlapSphere(transform.position,attackRadius);

        foreach(Collider c in colliders)
        {
            if(c.CompareTag("Enemy"))
            {
                // enemyCount++;
                // Debug.Log("Enemy Count : "+enemyCount);
                if(gm.ManaCount >= manaCost)
                {
                    StartCoroutine(CastEffect(0.9f));
                    gm.DecreaseMana(manaCost);
                    HitTarget(c.transform);
                }
            }
        }
    }

    void HitTarget(Transform target)
    {
        GameObject effects = (GameObject) Instantiate(impactFX,target.transform.position,Quaternion.Euler(90,0,0));

        Destroy(effects,2.0f);
        
        Damage(target);
    }

    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if(e != null)
        {   
            e.Slow(slowSpeed);
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
