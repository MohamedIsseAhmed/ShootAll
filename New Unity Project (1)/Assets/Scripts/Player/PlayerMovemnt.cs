using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovemnt : MonoBehaviour
{
    [SerializeField] private float speed = 9;

    private float minXRange = -7.50f;
    private float maxXRange = 7.50f;

   public enum MovementType
    {
        Normal,
        OnFinishPoint
    }
    public MovementType movementType = MovementType.Normal;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovemnt();
    }

    private void HandleMovemnt()
    {
        if(movementType == MovementType.Normal)
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
        if(movementType == MovementType.OnFinishPoint)
        {
           
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
       
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
}
