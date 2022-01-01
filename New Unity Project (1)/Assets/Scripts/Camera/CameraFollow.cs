using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Vector3 offset;
    [SerializeField] float slerpValue;
    [SerializeField] float lerpValue;
    [SerializeField] float distanceModifier;
    private void Awake()
    {
        FinishPoint.OnFinsihPointEvent += FinishPoint_OnFinsihPointEvent;
        FinishPoint.InformEnemyBigGuy += FinishPoint_OnFinsihPointEvent;
    }

   

    private void FinishPoint_OnFinsihPointEvent()
    {
      
        print("Camera");
        offset.x = 2.69000006f;
        offset.y = 2.20000005f;
        offset.z = -14.5799999f;
        distanceModifier = -11.79f;
    }

    void Update()
    {
        FollowPlAYER();
    }
    private void LateUpdate()
    {
       //transform.position = player.position+offset;
    }
    private void FollowPlAYER()
    {
        if (player != null)
        {
            Vector3 lookDirection = player.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(lookDirection);

            Vector3 targetPosition = player.position + offset - (player.forward * distanceModifier);

            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, slerpValue * Time.deltaTime);

            transform.position = Vector3.Lerp(transform.position, targetPosition, lerpValue * Time.deltaTime);
        }
        
    }
}
