using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private Transform projectileSpawnPosition;

    public static ProjectileSpawner Instance;
    public List<Projectile> projectiles;
    public Projectile objectToPool;
    public int poolAmount;
    private void Awake()
    {
         Instance = this;
    }
    void Start()
    {
        projectiles = new List<Projectile>();
        Projectile temp;
        for (int i = 0; i < poolAmount; i++)
        {
            temp = Instantiate(objectToPool);
            temp.gameObject.transform.SetParent(this.transform);
            temp.gameObject.SetActive(false);
            projectiles.Add(temp);
        }
    }

    public Projectile GetPoolObjects()
    {
        for (int i = 0; i < poolAmount; i++)
        {
            if (!projectiles[i].gameObject.activeInHierarchy)
            {
                
                return projectiles[i];
                
            }
        }
        return null;
    }
  
}
