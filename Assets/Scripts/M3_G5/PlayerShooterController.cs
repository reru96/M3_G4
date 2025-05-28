using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class PlayerShooterController : MonoBehaviour
{
    [SerializeField] public float fireRate = 0.5f;
    [SerializeField] public float fireRange = 40f;
    [SerializeField] Bullet bulletPrefab;
    [SerializeField] private Transform firePoint;

    private float nextFireTime = 0.25f;
   

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Time.time >= nextFireTime)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            Transform nearestEnemy = FindNearestEnemy(enemies); 

            if (nearestEnemy != null)
            {
                float distance = Vector2.Distance(transform.position, nearestEnemy.position);
                if (distance <= fireRange)
                {
                    Vector2 dir = (nearestEnemy.position - firePoint.position).normalized;
                    Shoot(dir);
                    nextFireTime = Time.time + fireRate;
                }
            }
        
        }
    }
    private void Shoot(Vector2 dir)
    {
        Bullet bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.dir = dir;
    }

    private Transform FindNearestEnemy(GameObject[] enemies)
    {
        Transform nearestEnemy = null;
        float shortestDistance = float.MaxValue;
        Vector2 currentPosition = transform.position;
        
        foreach (GameObject enemy in enemies)
        {
            if (enemy == null) continue;

            float distance = Vector2.Distance(currentPosition, enemy.transform.position);

            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                nearestEnemy = enemy.transform;
            }
        }

        return nearestEnemy;
    }
}
