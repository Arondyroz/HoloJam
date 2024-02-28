using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float fireRate = 1f;
    public float projectileSpeed = 3f;
    private float nextFireTime;
    private List<GameObject> projectilePool = new List<GameObject>();
    private int poolSize = 5;
    private Transform bulletPoint;

    public enum MonsterType
    {
        Brat,
        ChaosBeet,
        ChaosOwl,
    }

    public MonsterType monsterType;

    void Start()
    {
        bulletPoint = gameObject.transform.GetChild(0);
        // Populate the projectile pool
        for (int i = 0; i < poolSize; i++)
        {
            GameObject projectile = Instantiate(projectilePrefab);
            projectile.transform.parent = gameObject.transform;
            projectile.SetActive(false);
            projectilePool.Add(projectile);
        }
    }

    void Update()
    {
        switch(monsterType)
        {
            case MonsterType.Brat:
                BratControl();
                break;
            case MonsterType.ChaosBeet:
                break;
            case MonsterType.ChaosOwl:
                break;
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
