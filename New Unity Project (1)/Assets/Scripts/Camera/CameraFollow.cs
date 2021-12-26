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
    }

    private void FinishPoint_OnFinsihPointEvent()
    {
        offset.y = 4.05f;
        offset.z = -11.5f;
        distanceModifier = 0.86f;
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
        Vector3 lookDirection = player.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(lookDirection);

        Vector3 targetPosition = player.position + offset - (player.forward * distanceModifier);

        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, slerpValue * Time.deltaTime);

        transform.position = Vector3.Lerp(transform.position, targetPosition, lerpValue * Time.deltaTime);
    }
}
