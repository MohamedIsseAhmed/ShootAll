using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] GameObject player;
    //[SerializeField] LayerMask LayerMask;
    NavMeshAgent agent;
    [SerializeField] Animator animator;
    private void Awake()
    {
      
    }

    

    public void OnEnemyDestroyed()
    {
        animator.SetTrigger("Death");
        Destroy(gameObject, 5);
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = 2;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Vector3.Distance(player.transform.position, transform.position) < 10)
        //{
        //    print("Attack");
        //    Attack();
        //}
         CastRay();


    }

    private void Attack()
    {
        float distance = Mathf.Infinity;
        Transform choosenTarget=null;
        for (int i = 0; i < GameManager.Instance.freinds.Count; i++)
        {
            Vector3 choosenDirection = GameManager.Instance.freinds.Pop().transform.localPosition-transform.position;
            Vector3 choosenPosition = GameManager.Instance.freinds.Pop().transform.localPosition + choosenDirection.normalized;
            if (Vector3.Distance(GameManager.Instance.freinds.Pop().transform.localPosition, transform.position) < distance)
            {
                distance = Vector3.Distance(choosenDirection, transform.position);
                choosenTarget = GameManager.Instance.freinds.Pop().transform;
               
            }
        }
        print(choosenTarget.gameObject.name);
       // agent.SetDestination(choosenTarget.position);
        Quaternion lookRotation = Quaternion.LookRotation(choosenTarget.localPosition-transform.position);
        transform.rotation = lookRotation;
        animator.SetBool("Running", true);
        transform.Translate(Vector3.forward * 5 * Time.deltaTime);
       // animator.applyRootMotion = true;
        //if (agent.stoppingDistance <= 2)
        //{
        //    print("Attack Now");
        //}
        
    }

    private void CastRay()
    {
        Ray ray=new Ray(transform.position, transform.forward * 50);
        RaycastHit hit;
        int bit = 1<<7;
       // Debug.Log(System.Convert.ToString(bit, 2).PadLeft(32,'0'));
        if (Physics.Raycast(ray, out hit, 50,bit))
        {
            if(hit.collider != null)
            {
               
                hit.collider.GetComponent<Friend>().GoToEnemy(this);

            }
            Debug.DrawRay(transform.position, transform.forward * 50, Color.red);
            Vector3 directionToTarget=hit.collider.transform.localPosition - transform.position;
            directionToTarget.y = 1;
            // transform.position=Vector3.Lerp(transform.position,directionToTarget,1*Time.deltaTime);
            animator.SetBool("Running", true);
           // agent.SetDestination(hit.collider.gameObject.transform.localPosition);
          
           
            transform.Translate(Vector3.forward * 5 * Time.deltaTime);
            // animator.applyRootMotion=true;

        }
        else
        {
            animator.SetBool("Running", false);
            Debug.DrawRay(transform.position, transform.forward * 100, Color.yellow);
            animator.applyRootMotion = false;
        }
      
    }
 
}
