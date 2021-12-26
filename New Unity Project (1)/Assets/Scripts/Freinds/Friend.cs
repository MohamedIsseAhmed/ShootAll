using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friend : MonoBehaviour
{
    [SerializeField] private PlayerMovemnt  player;
    [SerializeField] private GameObject hand;
    [SerializeField] private GameObject weapon;
   [SerializeField] private Animator animator;
    [SerializeField] AudioClip collisionSound;
    public static event System.Action OnEnemyDestroyed;
    float weight=1;
    public LevelType levelType;

    public static Friend Instance;
    private void Awake()
    {
        Instance = this;
        FinishPoint.OnFinsihPointEvent += FinishPointOn;
    }

    private void FinishPointOn()
    {
        print("FriendDance");
        transform.parent = null;
        transform.eulerAngles = new Vector3(0,180,0);
        transform.position=new Vector3(transform.position.x, transform.position.y, transform.position.z);
        animator.SetTrigger("Dance");
       
    }

    void Start()
    {
       //animator=GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        //if (gameObject.activeSelf)
        //{
        //    weapon.transform.localRotation = hand.transform.localRotation;
        //}
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

    public void GoToEnemy(EnemyAI  enemy)
    {
        transform.parent = null;
        Vector3 direction = (enemy.transform.position - transform.position).normalized;
        Quaternion lookDirection= Quaternion.LookRotation(direction);
        transform.position = Vector3.Lerp(transform.position,enemy.transform.position+new Vector3(0,0,-1),1*Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation,lookDirection,1*Time.deltaTime);
    }
    
    private void OnTriggerEnter(Collider target)
    {
        if (target.CompareTag("Enemy"))
        {
            if (levelType == LevelType.collision)
            {
                OnEnemyDestroyed?.Invoke();
                animator.SetTrigger("Death");
                target.GetComponent<EnemyAI>().OnEnemyDestroyed();
                //transform.position=new Vector3(transform.position.x, -0.57f,transform.position.z);
                //transform.rotation = Quaternion.Euler(5.13f, transform.rotation.y, transform.rotation.z);
                print("Destroy Both");
                SoundManager.Instance.PlaySound(collisionSound);
            }
        }
        
    }
}
