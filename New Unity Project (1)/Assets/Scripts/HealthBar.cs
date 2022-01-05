using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Image healthBarSprite;
    [SerializeField] AudioClip enemyHitSound;
    public static event System.Action OnBigGuyDestroyed;
    private Camera camera;
    private void Start()
    {
        camera = Camera.main;
    }
    public void UpdateHealthBar(float maxHealth, float currentHealth)
    {
        print("FillA");
        healthBarSprite.fillAmount = maxHealth/ currentHealth;
        print(healthBarSprite.fillAmount.ToString("0.00"));
       
        if (healthBarSprite.fillAmount == 0)
        {
            SoundManager.Instance.StopPlayingSound();
            OnBigGuyDestroyed?.Invoke();
        }
       
    }

    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position -camera.transform.position);

    }
}
