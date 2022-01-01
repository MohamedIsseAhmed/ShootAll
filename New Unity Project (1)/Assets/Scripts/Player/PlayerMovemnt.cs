using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovemnt : MonoBehaviour,IDamagable
{
    [SerializeField] private float speed = 9;

    private float minXRange = -7.50f;
    private float maxXRange = 7.50f;

    [SerializeField] float health;

    public static event System.Action OnPlayerDestroyedEvent;


    //public GameManager.MovementType movementType;
    void Start()
    {
        //FinishPoint.InformEnemyBigGuy += FinishPoint_InformEnemyBigGuy;
    }

    //private void FinishPoint_InformEnemyBigGuy()
    //{
    //   movementType = MovementType.Punch;
    //}

    // Update is called once per frame
    void Update()
    {
        HandleMovemnt();
    }

    private void HandleMovemnt()
    {
        if(GameManager.Instance.GetMovementType == GameManager.MovementType.Normal)
        {
            if (Input.GetMouseButton(0))
            {
                float moseX = Input.GetAxis("Mouse X");
                float mouseY = Input.GetAxis("Mouse Y");

                Vector3 movemnt = new Vector3(moseX, 0, 0);

                transform.position += movemnt;

            }

            if (Input.GetMouseButtonUp(0))
            {

            }
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            ConstraintPlayerXposition();
        }
        if (GameManager.Instance.GetMovementType == GameManager.MovementType.OnFinishPoint)
        {

            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
        //if (GameManager.Instance.GetMovementType == GameManager.MovementType.Punch && GameManager.Instance.isPunchingTime)
        //{
        //    float rotation = Input.GetAxis("Horizontal");
        //    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        //    rotation *= 10 * Time.deltaTime;
        //    //transform.Rotate(0, rotation, 0);
           
            
        //}

    }

    private void ConstraintPlayerXposition()
    {
        if(transform.position.x < minXRange)
        {
            transform.position=new Vector3(minXRange,transform.position.y,transform.position.z);
        }
        if(transform.position.x > maxXRange)
        {
            transform.position = new Vector3(maxXRange, transform.position.y, transform.position.z);
        }
    }

    public void TakeDame(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            OnPlayerDestroyedEvent?.Invoke();
            Destroy(gameObject, 1);
        }
    }

   
}
