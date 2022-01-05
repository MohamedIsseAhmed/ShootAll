using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
public class Crate : MonoBehaviour, IDamagable
{
    [SerializeField] TextMeshPro m_Text;
    [SerializeField] float crateHealthPoints;
    public static event System.Action KillTweening;
    void Start()
    {
        m_Text.text = crateHealthPoints.ToString();
    }

  
    public void TakeDame(float damage)
    {
        crateHealthPoints -= damage;
        m_Text.text = crateHealthPoints.ToString();
        if (crateHealthPoints < 0)
        {
            
            Destroy(gameObject);
        }
    }
}
