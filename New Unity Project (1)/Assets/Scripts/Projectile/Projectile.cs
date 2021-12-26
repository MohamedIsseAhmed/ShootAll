using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
   [SerializeField] float speed = 20;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Enemy"))
        {
            print("Hit enemy");
            IDamagable damagable = other.gameObject.GetComponent<IDamagable>();
            if (damagable != null)
            {
                damagable.TakeDame(10);
            }
        }
        if (other.CompareTag("crate"))
        {
           
            Crate crate = other.gameObject.GetComponent<Crate>();
            if(crate != null)
            {
                crate.TakeHit(10);
            }
        }
    }

}
