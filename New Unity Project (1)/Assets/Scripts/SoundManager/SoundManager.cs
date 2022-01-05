using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [SerializeField] AudioClip collisionSound;
    private AudioSource audioSource;
    void Awake()
    {
        
      

        if (FindObjectsOfType<SoundManager>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
       
    }
    public void PlaySound(AudioClip audioClip)
    {
        if(audioSource != null)
        {
            audioSource.PlayOneShot(audioClip);
        }
       
    }
    private void Update()
    {
        if(audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }
    private void OnEnable()
    {
        print("start");
        audioSource = GetComponent<AudioSource>();
       
    }
    public void StopPlayingSound()
    {
        if (audioSource != null)
        {
            StartCoroutine(Volume());
            audioSource.Stop();
        }
       
    }
    IEnumerator Volume()
    {
        audioSource.volume = 0;
        yield return new WaitForSeconds(2);
        audioSource.volume = 1;
    }
    public void PlayCollisionSound()
    {
        if (audioSource != null)
        {
            audioSource.PlayOneShot(collisionSound);
        }
       
    }
}
