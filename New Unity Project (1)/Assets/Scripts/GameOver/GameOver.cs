using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject flag;
    [SerializeField] TextMeshProUGUI dimonCount;

    [SerializeField] GameObject fail;
    public static GameOver Instance;
    void OnEnable()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        FinishPoint.OnFinsihPointEvent += FinishPoint_OnFinsihPointEvent;
        PlayerMovemnt.OnPlayerDestroyedEvent += PlayerMovemnt_OnPlayerDestroyedEvent;
        HealthBar.OnBigGuyDestroyed += FinishPoint_OnFinsihPointEvent;
    }

    private void PlayerMovemnt_OnPlayerDestroyedEvent()
    {
        fail.SetActive(true);
        dimonCount.text = "Dimonds " + FindObjectOfType<ScoreManager>().DimondCount;
    }

    private void FinishPoint_OnFinsihPointEvent()
    {
        if (PlayerPrefs.GetInt("Level") >= 3)
        {
            flag.gameObject.SetActive(true);
        }
      
        if (gameObject!=null)
           StartCoroutine(GameOverCoroutine());
    }
    IEnumerator GameOverCoroutine()
    {
        yield return null;

        gameOver.SetActive(true);
        dimonCount.text = " Dimonds " + FindObjectOfType<ScoreManager>().DimondCount.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDisable()
    {
        FinishPoint.OnFinsihPointEvent -= FinishPoint_OnFinsihPointEvent;
        PlayerMovemnt.OnPlayerDestroyedEvent -= PlayerMovemnt_OnPlayerDestroyedEvent;
        HealthBar.OnBigGuyDestroyed -= FinishPoint_OnFinsihPointEvent;
    }
  
    private void OnDestroy()
    {
        print("Destroying Game Over");
    }
}
