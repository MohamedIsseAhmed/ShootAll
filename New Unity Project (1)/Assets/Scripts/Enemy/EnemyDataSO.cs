using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Enemy Data",fileName ="EnemyData",order =51)]
public class EnemyDataSO : ScriptableObject
{
    public float minHealth;
    public float maxHealth;

}
