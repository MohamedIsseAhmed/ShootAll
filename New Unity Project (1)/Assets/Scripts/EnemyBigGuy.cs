using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBigGuy : MonoBehaviour,IAim
{
    NavMeshAgent agent;
    Animator animator;
    public static EnemyBigGuy Instance;
    [SerializeField] SkinnedMeshRenderer skinnedMesh;
    private bool fightWithPlayer;
    [SerializeField] float distance = 3f;
    [SerializeField] Vector3 offset;
    [SerializeField] Transform meatingPoint;
    [SerializeField] Transform player;

    [SerializeField] float currentHealth;
    [SerializeField] float maxHealth;

    public float GetCurrentHealth { get { return currentHealth; } set { currentHealth = value; } }
    public float GetMaxHealth { get { return currentHealth; }  }
    [SerializeField] EnemyDataSO enemyData;

   [SerializeField] HealthBar healthBar;
    void Awake()
    {
      
    }
    private void OnEnable()
    {
           animator=transform.GetChild(1).GetComponent<Animator>();
           Instance = this;

        //agent = GetComponent<NavMeshAgent>();
        //FinishPoint.InformEnemyBigGuy += FinishPoint_InformEnemyBigGuy; 
        skinnedMesh.enabled = false;
        FinishPoint.InformEnemyBigGuy += FinishPoint_InformEnemyBigGuy;
        HealthBar.OnBigGuyDestroyed += HealthBar_OnBigGuyDestroyed;
    }
    private void FinishPoint_InformEnemyBigGuy()
    {
        skinnedMesh.enabled=true;
      
        //print(player.name);

        fightWithPlayer = true;
    }

    private void Start()
    {
        //maxHealth = enemyData.maxHealth;
        //currentHealth = enemyData.minHealth;
     
    }
   
    private void HealthBar_OnBigGuyDestroyed()
    {
        
        animator.SetTrigger("Death");
    }

    // Update is called once per frame
    void Update()
    {
        if (fightWithPlayer)
        {
            Aim(meatingPoint,player);
        }
    }
  
   
    private void OnDisable()
    {
        FinishPoint.InformEnemyBigGuy -= FinishPoint_InformEnemyBigGuy;
        HealthBar.OnBigGuyDestroyed -= HealthBar_OnBigGuyDestroyed;
    }
    public void ReduceHealthValue()
    {
        currentHealth -= 1;
        healthBar.UpdateHealthBar(currentHealth,maxHealth);
    }
   

    public void Aim(Transform target, Transform _directionToLook)
    {

        if (target != null)
        {
            Vector3 directionToTraget = (target.position - transform.position);
            Vector3 directionToLook = (_directionToLook.position - transform.position);
            Quaternion lookDirection = Quaternion.LookRotation(directionToLook);
            Vector3 targetPosition = target.transform.position;
            targetPosition.y = 0;
            transform.position = Vector3.Lerp(transform.position, targetPosition + offset, 1 * Time.deltaTime);
            lookDirection.x = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, lookDirection, 1 * Time.deltaTime);
            if (Vector3.Distance(target.position, transform.position) < 4)
            {
                animator.SetTrigger("Punch");
            }
            if (Vector3.Distance(target.position, transform.position) < distance)
            {

                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            }
        }
    }

    
}
