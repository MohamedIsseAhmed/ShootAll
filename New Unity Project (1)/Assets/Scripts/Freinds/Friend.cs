using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friend : MonoBehaviour,IAim
{
    [SerializeField] private PlayerMovemnt  player;
    [SerializeField] private GameObject hand;
    [SerializeField] private GameObject weapon;
   [SerializeField] private Animator animator;
    
    [SerializeField] Transform targetTo;
    GameObject[] meatingPoint;
    [SerializeField] Vector3 offset;
    [SerializeField] float distance;
    public static event System.Action OnEnemyDestroyed;
    float weight=1;
    public LevelController.LevelType levelType;

    public static Friend Instance;
    [SerializeField] SkinnedMeshRenderer bodyColor;
    int randomTarget;
    private void Awake()
    {
        meatingPoint = GameObject.FindGameObjectsWithTag("Point");
        print(meatingPoint.Length);
        Instance = this;
       FinishPoint.OnFinsihPointEvent += FinishPointOn;
        //if (gameObject != null)
        //{
        //    transform.parent = player.transform;
        //}
        if(player != null)
             bodyColor.material.color = FindObjectOfType<RandomColorGenerator>().GetBodyColor;

        HealthBar.OnBigGuyDestroyed += FinishPointOn;
    }

  

    private void FinishPointOn()
    {
       
        if (gameObject != null)
        {
           
            transform.parent = null;
            transform.eulerAngles = new Vector3(0, 180, 0);
            transform.position = new Vector3(transform.position.x, -0.12F, transform.position.z);
            animator.SetTrigger("Dance");

        }
      

    }

    void Start()
    {
        //animator=GetComponent<Animator>();   
        randomTarget = Random.Range(0, meatingPoint.Length);
    }

    // Update is called once per frame
    void Update()
    {
        //if (gameObject.activeSelf)
        //{
        //    weapon.transform.localRotation = hand.transform.localRotation;
        //}
        //if (gameObject.activeSelf)
        //{
        //    bodyColor.material.color = FindObjectOfType<RandomColorGenerator>().GetBodyColor;
        //}
        if (LevelController.instance.LevelTypes == LevelController.LevelType.Punching && GameManager.Instance.isPunchingTime)
        {
            animator.SetTrigger("Punch");
         
            Aim(meatingPoint[randomTarget].transform,FindObjectOfType<EnemyBigGuy>().transform);
        }
    }

    //private void OnAnimatorIK(int layerIndex)
    //{
    //    print("pick weapon");
    //    weight = animator.GetFloat("IKR");
    //    if (layerIndex != 0)
    //    {
    //        print("pick weapon");
    //    }
    //    animator.SetIKPositionWeight(AvatarIKGoal.LeftHand,weight);
    //    animator.SetIKPosition(AvatarIKGoal.RightHand, weapon.transform.localPosition);
    //}

    public void GoToEnemy(EnemyAI  targetEnemy)
    {
        transform.parent = null;
        Vector3 direction = (targetEnemy.transform.position - transform.position).normalized;
        Quaternion lookDirection= Quaternion.LookRotation(direction);
        transform.position = Vector3.Lerp(transform.position, targetEnemy.transform.position+new Vector3(0,0,-1),1*Time.deltaTime);
       transform.rotation = Quaternion.Slerp(transform.rotation,lookDirection,1*Time.deltaTime);
      
    }

    
    private void OnTriggerEnter(Collider target)
    {
        if (target.CompareTag("Enemy") || target.CompareTag("crate"))
        {
            Destroy(gameObject, 1);
            if (levelType == LevelController.LevelType.collision )
            {
                OnEnemyDestroyed?.Invoke();
                animator.SetTrigger("Death");
                if (target.GetComponent<EnemyAI>())
                {
                    target.GetComponent<EnemyAI>().OnEnemyDestroyed();
                }

                //transform.position=new Vector3(transform.position.x, -0.57f,transform.position.z);
                //transform.rotation = Quaternion.Euler(5.13f, transform.rotation.y, transform.rotation.z);

                SoundManager.Instance.PlayCollisionSound();
             
            }
            else if (levelType == LevelController.LevelType.Punching)
            {
                OnEnemyDestroyed?.Invoke();
                animator.SetTrigger("Death");
                if (target.GetComponent<EnemyAI>())
                {
                    target.GetComponent<EnemyAI>().OnEnemyDestroyed();
                }
                //transform.position=new Vector3(transform.position.x, -0.57f,transform.position.z);
                //transform.rotation = Quaternion.Euler(5.13f, transform.rotation.y, transform.rotation.z);

                SoundManager.Instance.PlayCollisionSound();
                
            }
        }
        
    }
    private void OnDisable()
    {
        FinishPoint.OnFinsihPointEvent -= FinishPointOn;
    }
    private void OnDestroy()
    {
        FinishPoint.OnFinsihPointEvent -= FinishPointOn;
        HealthBar.OnBigGuyDestroyed -= FinishPointOn;
    }

    public void Aim(Transform target, Transform _directionToLook)
    {
        Vector3 directionToTraget = (target.position - transform.position);
        Vector3 directionToLook = (_directionToLook.position - transform.position);
        
        Quaternion lookDirection = Quaternion.LookRotation(directionToLook);
        Vector3 targetPosition = target.transform.position;
        targetPosition.y = 0;   
        transform.position = Vector3.Lerp(transform.position, targetPosition + offset, 1 * Time.deltaTime);
        lookDirection.x = 0;
       lookDirection.z = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, lookDirection, 1 * Time.deltaTime);
        
        // transform.LookAt(_directionToLook);
        if (Vector3.Distance(target.position, transform.position) < distance)
        {

            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
    }
}
