using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject gameOver;
    [SerializeField] TextMeshProUGUI dimonCount;

    [SerializeField] GameObject fail;
   
    void Awake()
    {
        FinishPoint.OnFinsihPointEvent += FinishPoint_OnFinsihPointEvent;
        PlayerMovemnt.OnPlayerDestroyedEvent += PlayerMovemnt_OnPlayerDestroyedEvent;
    }

    private void PlayerMovemnt_OnPlayerDestroyedEvent()
    {
        fail.SetActive(true);
        dimonCount.text = "Dimonds " + FindObjectOfType<ScoreManager>().DimondCount;
    }

    private void FinishPoint_OnFinsihPointEvent()
    {
        gameOver.SetActive(true);
        dimonCount.text =" Dimonds " +FindObjectOfType<ScoreManager>().DimondCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDisable()
    {
        FinishPoint.OnFinsihPointEvent -= FinishPoint_OnFinsihPointEvent;
        PlayerMovemnt.OnPlayerDestroyedEvent -= PlayerMovemnt_OnPlayerDestroyedEvent;
    }
 
}
