using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    public static event System.Action OnFinsihPointEvent;
    public static event System.Action OnleyelTypePunching;
    public static event System.Action InformEnemyBigGuy;
    void Start()
    {
        
    }


    private void OnTriggerEnter(Collider target)
    {
        
        if(target.CompareTag("Player") && LevelController.instance.LevelTypes == LevelController.LevelType.collision)
        {
            
            OnFinsihPointEvent?.Invoke();
        }
        else if (target.CompareTag("Player") && LevelController.instance.LevelTypes == LevelController.LevelType.Punching)
        {
            print("punch start");
           
            InformEnemyBigGuy?.Invoke();
            //EnemyBigGuy.Instance.FighthWithPlayer(target.transform);
            //if (LevelController.instance.LevelTypes == LevelController.LevelType.Punching)

        }

    }
}
