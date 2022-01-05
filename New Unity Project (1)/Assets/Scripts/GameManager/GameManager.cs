using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static GameManager Instance;
    public Stack<Transform> freinds = new Stack<Transform>();

    public bool isPunchingTime;
    public enum MovementType
    {
        Normal,
        OnFinishPoint,
        Punch
    }
    private MovementType movementType;  
    public MovementType GetMovementType { get { return movementType; } set { movementType = value; } }
    private void Awake()
    {
        Instance = this;
        movementType = MovementType.Normal;

        FinishPoint.InformEnemyBigGuy += FinishPoint_InformEnemyBigGuy;
        FinishPoint.OnFinsihPointEvent += FinishPoint_OnFinsihPointEvent;
    }

    private void FinishPoint_OnFinsihPointEvent()
    {
       movementType = MovementType.Punch;
    }
    
    private void FinishPoint_InformEnemyBigGuy()
    {
        isPunchingTime = true;
        movementType = MovementType.OnFinishPoint;
    }
    
}
