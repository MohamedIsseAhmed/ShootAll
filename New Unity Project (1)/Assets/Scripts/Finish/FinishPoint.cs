using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    public static event System.Action OnFinsihPointEvent;
    void Start()
    {
        
    }


    private void OnTriggerEnter(Collider target)
    {
        if(target.CompareTag("Player") )
        {
            print("Victory Dance");
            OnFinsihPointEvent?.Invoke();
            //Friend.Instance.FinishPointOn();
        }
        if (target.CompareTag("Friend"))
        {
            //print("Friend Dance");
           // Friend.Instance.FinishPointOn();
        }
    }
}
