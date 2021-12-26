using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static GameManager Instance;
    public Stack<Transform> freinds = new Stack<Transform>();
    private void Awake()
    {
        Instance = this;
    }

   
}
