using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Transform gun;
    [SerializeField] LayerMask mask;
    [SerializeField] ProjectileSpawner projectile;
    [SerializeField] private Transform projectilePosition;

    [SerializeField] private float timeAfterToActivatePooledObjects = 1;

    [SerializeField] private Animator animator;

    private float timeBetweenShoots = 0.1f;
    float nextShootTime;

    private Coroutine coroutine;
    void Awake()
    {
        FinishPoint.OnFinsihPointEvent += FinishPoint_OnFinsihPointEvent;
    }

    private void FinishPoint_OnFinsihPointEvent()
    {
        StartCoroutine(TurnProcessCompletor());
    }
    IEnumerator Turn()
    {
        GetComponent<PlayerMovemnt>().movementType = PlayerMovemnt.MovementType.OnFinishPoint;
        transform.eulerAngles=new Vector3(0,180,0);
        animator.SetTrigger("Dance");
        yield return null;
    }
    IEnumerator TurnProcessCompletor()
    {
        yield return StartCoroutine(Turn());
    }
    void Update()
    {
        ShootEnemy();

        if (Input.GetMouseButton(0))
        {
            animator.SetBool("RifleRun", true);
            if (Time.time > nextShootTime)
            {
             
                nextShootTime = Time.time+timeBetweenShoots;
                StartCoroutine(ShootEnemy());
            }
           
          
        }
        if (Input.GetMouseButtonUp(0))
        {
            animator.SetBool("RifleRun", false);
            StopCoroutine(ShootEnemy());
        }
    }

    IEnumerator ShootEnemy()
    {

        Ray ray = new Ray(gun.position, gun.forward * 1000);
        RaycastHit raycastHit;
        //LayerMask mask=1;
        //mask |= mask << 7;
        Projectile newProjectile = ProjectileSpawner.Instance.GetPoolObjects();
        if (newProjectile != null)
        {
            newProjectile.transform.position = projectilePosition.position;
            newProjectile.transform.rotation = projectilePosition.rotation;
            newProjectile.gameObject.SetActive(true);
        }
        
        StartCoroutine(DeActivatePooledObjects(newProjectile));
        yield return null;
    }
    IEnumerator DeActivatePooledObjects(Projectile projectile)
    {
        yield return new WaitForSeconds(timeAfterToActivatePooledObjects);
        projectile.gameObject.SetActive(false);
    }
}
