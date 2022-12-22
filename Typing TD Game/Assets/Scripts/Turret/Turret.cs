using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("Attributes")]
    public float range = 15f;
    public float fireRate = 1.0f;
    private float fireCountdown = 0.0f;
    public int manaCost;

    [Header("Enemy & Turret Stuff")]
    public Transform target;
    public string enemyTag = "Enemy";
    public GameObject bullet;
    public Transform firePoint;
    // public Transform partToRotate;
    // private float turnSpeed = 5.0f;
    private bool noTarget = true;
    GameManager gm;
    
    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.instance;
        InvokeRepeating("UpdateTarget",0f,1.0f);
    }

    void UpdateTarget()
    {
        if(noTarget == true)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
            float enemyDistance;
            float shortestDistance = Mathf.Infinity;
            GameObject nearestEnemy = null;

            foreach (GameObject enemy in enemies)
            {
                enemyDistance = Vector3.Distance(transform.position,enemy.transform.position);

                if(shortestDistance > enemyDistance)
                {
                    shortestDistance = enemyDistance;
                    nearestEnemy = enemy;
                }
            }

            if(nearestEnemy != null && shortestDistance <= range)
            {
                target = nearestEnemy.transform;
            }
            else
            {
                target = null;
            }

            noTarget = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
            //Target Lock On
            Vector3 direction = target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            // Vector3 rotation = Quaternion.Lerp(partToRotate.rotation,lookRotation,turnSpeed * Time.deltaTime).eulerAngles;
            // partToRotate.rotation = Quaternion.Euler(0f,rotation.y,0f);
        
            if(fireCountdown <= 0f && gm.ManaCount >= manaCost)
            {
                Shoot();
                fireCountdown = 1.0f/fireRate;
            }

            fireCountdown-=Time.deltaTime;
        }

        if(target == null || Vector3.Distance(transform.position,target.transform.position) > range)
        {
            //Update Target
            noTarget = true;
        }
    }

    void Shoot()
    {
        gm.DecreaseMana(manaCost);
        
        GameObject bulletGO = (GameObject) Instantiate(bullet,firePoint.position,Quaternion.identity);

        Bullet bulletScript = bulletGO.GetComponent<Bullet>();

        if(bulletScript != null) 
        {
            bulletScript.Search(target);
        }
    }

    private void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,range); 
    }   
}
