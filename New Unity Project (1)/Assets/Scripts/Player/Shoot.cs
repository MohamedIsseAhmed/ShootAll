using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour,IAim
{
    [SerializeField] private Transform gun;
    [SerializeField] LayerMask mask;
    [SerializeField] ProjectileSpawner projectile;
    [SerializeField] private Transform projectilePosition;

    [SerializeField] private float timeAfterToActivatePooledObjects = 1;

    [SerializeField] private Animator animator;

    [SerializeField] float distance=2;
    [SerializeField] Vector3 offset;
    [SerializeField] AudioClip[] enemyHitSounds;
    Transform meatingPoint;
    EnemyBigGuy targetEnemy;
    private float timeBetweenShoots = 0.1f;
    float nextShootTime;

    bool isGameOver = false;

    private PlayerMovemnt player;
    private Coroutine coroutine;
    public static Shoot Instance;
    public  Shoot ShootInstance;
    void Awake()
    {
    }
    private void OnEnable()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        
      
        player = GetComponentInParent<PlayerMovemnt>();
        FinishPoint.OnFinsihPointEvent += FinishPoint_OnFinsihPointEvent;
        HealthBar.OnBigGuyDestroyed += FinishPoint_OnFinsihPointEvent;
        meatingPoint = GameObject.Find("MeatingPoint").transform;
        targetEnemy = GameObject.Find("EnemyBigGuy").GetComponent<EnemyBigGuy>();
    }
    private void FinishPoint_OnFinsihPointEvent()
    {
      
        isGameOver = true;
        if (gameObject != null)
        {
            StartCoroutine(TurnProcessCompletor());
        }
     
    }
    IEnumerator Turn()
    {
        //GameManager.Instance.GetMovementType = GameManager.MovementType.OnFinishPoint;
        player.transform.eulerAngles=new Vector3(0,180,0);
        animator.SetTrigger("Dance");
        yield return null;
    }
    IEnumerator TurnProcessCompletor()
    {
        yield return StartCoroutine(Turn());
    }
    void Update()
    {
       // ShootEnemy();

        if (Input.GetMouseButton(0) && !isGameOver)
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
        if ( LevelController.instance.LevelTypes== LevelController.LevelType.Punching && GameManager.Instance.isPunchingTime)
        {
           
            isGameOver = true;
            if (Input.GetMouseButtonDown(0))
            {
                animator.SetFloat("Speed", 3);
               
                animator.SetTrigger("Punch");
            }
                
            if (Input.GetMouseButtonUp(0))
            {
                animator.SetFloat("Speed", 1);
               
            }
            Aim(meatingPoint, targetEnemy.transform);
        }
    }

  
    public void ReduceHealth()
    {
        if (gameObject != null)
        {
            targetEnemy.ReduceHealthValue();
            int randomSound = UnityEngine.Random.Range(0, enemyHitSounds.Length - 1);
            AudioClip hitSound = enemyHitSounds[randomSound];
            SoundManager.Instance.PlaySound(hitSound);
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

    void OnDisable()
    { 
         FinishPoint.OnFinsihPointEvent -= FinishPoint_OnFinsihPointEvent;
        HealthBar.OnBigGuyDestroyed -= FinishPoint_OnFinsihPointEvent;
        Debug.Log("PrintOnDisable: script was disabled");
    }
    private void OnDestroy()
    {
        
        print("destroying shoot object");
        //FinishPoint.OnFinsihPointEvent -= FinishPoint_OnFinsihPointEvent;
        //HealthBar.OnBigGuyDestroyed -= FinishPoint_OnFinsihPointEvent;
    }

    public void Aim(Transform target, Transform _directionToLook)
    {
        Vector3 directionToTraget = (target.position -player.transform.position);
        Vector3 directionToLook = (_directionToLook.position - player.transform.position);
        Quaternion lookDirection = Quaternion.LookRotation(directionToLook);
        Vector3 targetPosition = target.transform.position;
        targetPosition.y = 0;
        player.transform.position = Vector3.Lerp(player.transform.position, targetPosition + offset, 1 * Time.deltaTime);
        lookDirection.x = 0;
       player.transform.rotation = Quaternion.Slerp(player.transform.rotation, lookDirection, 1 * Time.deltaTime);
        if (Vector3.Distance(target.position, player.transform.position) < distance)
        {

            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        }
    }
}
