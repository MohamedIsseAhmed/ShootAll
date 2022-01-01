using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    private TextMeshProUGUI scoreText;
    private int score = 0;

    public object DimondCount { get { return score;} }

    public static ScoreManager Instance;
    private void Awake()
    {
       
      
       
        Instance = this;   
        if (FindObjectsOfType<ScoreManager>().Length>1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
          
        }
      
    }
    void Start()
    {
        InGameUI.IncreaseScore += InGameUI_IncreaseScore;
    }

    private void InGameUI_IncreaseScore()
    {
     
        score ++;

    }
    private void OnDestroy()
    {
        InGameUI.IncreaseScore -= InGameUI_IncreaseScore;
    }
    // Update is called once per frame
    void Update()
    {
     
        if (scoreText == null)
        {
            scoreText = GameObject.Find("DimondText").GetComponent<TextMeshProUGUI>();
            
        }
        scoreText.text = score.ToString();
    }
   
}
