using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI gameOverText;
    void Awake()
    {
        FinishPoint.OnFinsihPointEvent += FinishPoint_OnFinsihPointEvent;
    }

    private void FinishPoint_OnFinsihPointEvent()
    {
       gameOverText.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
