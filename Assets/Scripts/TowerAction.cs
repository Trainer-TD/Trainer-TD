using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAction : MonoBehaviour
{
    [Header("Set Tower GameObject")]
    public Tower tower; 

    [Header("General")]
    private float fireCountdown = 0f;
    private Transform target;
    private Enemy targetEnemy;

    [Header("Laser (optional)")]
    public bool useLaser = false;
    public LineRenderer lineRenderer;
    // public ParticleSystem impactEffect;
    // public Light impactLight;

    [Header("Prefabs")]
    public string enemyTag = "Enemy";
    public Transform rotatePart;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public GameObject shootEffect;

    void Start(){
        InvokeRepeating("UpdateTarget", 0f, 0.7f);
    }

    void UpdateTarget(){
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach(GameObject enemy in enemies){
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy <shortestDistance){
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistance <= tower.range){
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else{
            target = null;
        }
    }

    void Update() {
        if(target == null) {
            if (useLaser) {
                if (lineRenderer.enabled) {
                    lineRenderer.enabled = false;
                    // impactEffect.Stop();
                    // impactLight.enabled = false;
                }
            }
            return;
        }

        LockOnTarget();

        if (useLaser) {
            Debug.Log("Laser!");
        }
        else {
            if (fireCountdown <= 0) {
                Shoot();
                fireCountdown = 1f / tower.fireRate;
            }

            fireCountdown -= Time.deltaTime;
        }
    }

    void LockOnTarget () {
        Vector3 direction = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = lookRotation.eulerAngles;
        rotatePart.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void Shoot(){
        GameObject bulletMove = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletMove.GetComponent<Bullet>();
        GameObject effectIns = (GameObject)Instantiate(shootEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);

        if(bullet != null){
            bullet.Seek(target);
        }
    }
}
