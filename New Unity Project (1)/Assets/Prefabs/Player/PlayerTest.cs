using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    [SerializeField] float speed = 5;
    Animator animator;
    void Start()
    {
        animator=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       // transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (transform.position.z!=0)
        {
            //animator.SetBool("Walking", true);
        }
        else
        {
           // animator.SetBool("Walking", false);
        }
    }
}
