using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
  
    LevelType levelType;
    void Start()
    {
        levelType = LevelType.collision;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
public enum LevelType
{
    collision,
    Punching
};