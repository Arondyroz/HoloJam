using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float fireRate = 1f;
    public float projectileSpeed = 3f;
    public bool canAttack = false;
    private float nextFireTime;
    private List<GameObject> projectilePool = new List<GameObject>();
    private int poolSize = 5;
    private Transform bulletPoint;
    private Transform playerPos;
    private Transform objectPool;

    public enum MonsterType
    {
        Brat,
        ChaosBeet,
        ChaosOwl,
    }

    public MonsterType monsterType;

    void Start()
    {
        objectPool = GameObject.FindGameObjectWithTag("ObjectPool").GetComponent<Transform>();
        playerPos = GameObject.FindGameObjectWithTag("Bae").GetComponent<Transform>();
        bulletPoint = gameObject.transform.GetChild(0);
        // Populate the projectile pool
        for (int i = 0; i < poolSize; i++)
        {
            GameObject projectile = Instantiate(projectilePrefab);
            projectile.transform.parent = objectPool.transform;
            projectile.SetActive(false);
            projectilePool.Add(projectile);
        }
    }

    void Update()
    {
        if(canAttack == true)
            MonsterBeginAttacking();
    }

    public void MonsterBeginAttacking()
    {
        switch (monsterType)
        {
            case MonsterType.Brat:
                BratControl();
                break;
            case MonsterType.ChaosBeet:
                if (GameManager.instance.TimeCheck <= 90f)
                    ChaosBeetControl();
                break;
            case MonsterType.ChaosOwl:
                if (GameManager.instance.TimeCheck <= 45)
                    ChaosOwlControl();
                break;
        }
    }

    public void AttackCheck(bool check)
    {
        canAttack = check;
    }
     
    void ChaosOwlControl()
    {
        if (Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + 1f / fireRate;
            ChaosOwlShoot();
        }
    }

    void ChaosBeetControl()
    {
        if (Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + 1f / fireRate;
            ChaosBeetShoot();
        }
    }

    void BratControl()
    {
        if (Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void ChaosBeetShoot()
    {
        foreach (GameObject projectile in projectilePool)
        {
            if (!projectile.activeSelf)
            {
                projectile.SetActive(true);
                projectile.transform.position = bulletPoint.position;

                Vector3 lookDir = playerPos.position - bulletPoint.position;
                float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
                bulletPoint.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

                // Add Rigidbody component if not already present
                Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

                // Set the velocity of the Rigidbody to move the projectile
                rb.velocity = lookDir.normalized * projectileSpeed;

                break;
            }
        }
    }

    void ChaosOwlShoot()
    {
        // Calculate the base direction towards the player
        Vector3 baseDirection = (playerPos.position - bulletPoint.position).normalized;

        for (int i = 0; i < 4; i++)
        {
            // Calculate the angle for this projectile
            float angle = i * 12f;

            // Rotate the base direction by the angle
            Vector3 direction = Quaternion.Euler(0, 0, angle) * baseDirection;

            // Instantiate a projectile
            GameObject projectile = Instantiate(projectilePrefab, bulletPoint.position, Quaternion.identity);

            // Rotate the projectile to face the calculated direction
            projectile.transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);

            // Add Rigidbody component if not already present
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

            // Set the velocity of the Rigidbody to move the projectile
            rb.velocity = direction * projectileSpeed;
        }
    }

    void Shoot()
    {
        // Find an inactive projectile from the pool and activate it
        foreach (GameObject projectile in projectilePool)
        {
            if (!projectile.activeSelf)
            {
                projectile.SetActive(true);
                projectile.transform.position = bulletPoint.position;

                // Set the rotation of the projectile to match the direction
                projectile.transform.rotation = bulletPoint.rotation;

                // Add Rigidbody component if not already present
                Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

                // Set the velocity of the Rigidbody to move the projectile
                rb.AddForce(bulletPoint.up * projectileSpeed, ForceMode2D.Impulse);

                break;
            }
        }
    }

   
}
