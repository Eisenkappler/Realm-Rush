using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] ParticleSystem projectilesParticals;
    [SerializeField] float range = 15;
    Transform target;

    // Update is called once per frame
    void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }

    void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistant = Mathf.Infinity;

        foreach(Enemy enemy in enemies)
        {
            float targetDistant = Vector3.Distance(transform.position,enemy.transform.position);
            if(targetDistant < maxDistant)
            {
                closestTarget = enemy.transform;
                maxDistant = targetDistant;
            }
        }

        target = closestTarget;
    }
    void AimWeapon()
    {
        float targetDistant = Vector3.Distance(transform.position,target.position);
         
        if(targetDistant < range)
        {
            weapon.LookAt(target);
            Attack(true);
        }else{
            Attack(false);
        }

       
    }

    void Attack(bool isActive)
    {
        var emissionModule = projectilesParticals.emission;
        emissionModule.enabled = isActive;
    }
}
