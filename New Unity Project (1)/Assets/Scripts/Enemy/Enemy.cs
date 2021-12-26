using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour,IDamagable
{
    [SerializeField] float currentHealth;
    [SerializeField] private  EnemyDataSO enemyData;
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private  float expolosionForce = 100;
    [SerializeField] private  float expolosionRadius= 10;
    [SerializeField] private  Transform target;
    void Start()
    {
        currentHealth = enemyData.maxHealth;
    }

  
    void Update()
    {
        
    }

    public void TakeDame(float damage)
    {
        currentHealth-=damage;
        if(currentHealth <=enemyData.minHealth)
        {
            rigidbody.AddExplosionForce(expolosionForce, target.position, expolosionRadius);
             Destroy(gameObject);
            print("Destry Enemy");
        }
    }
}
