using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    
    public enum LevelType
    {
        collision,
        Punching
    };
    LevelType levelType;
    public LevelType LevelTypes { get { return levelType; } }
    private int currentLevel;
    public static LevelController instance;
    private void Awake()
    {
        instance = this;
       //PlayerPrefs.SetInt("Level", 0);
        currentLevel = PlayerPrefs.GetInt("Level", 0);
        FinishPoint.OnleyelTypePunching += FinishPoint_OnleyelTypePunching;
    }

    private void FinishPoint_OnleyelTypePunching()
    {
        levelType = LevelType.Punching;
      
    }

    void Start()
    {
        levelType = LevelType.collision;

        if (PlayerPrefs.GetInt("Level") == 1)
        {
            levelType=LevelType.Punching;
            print("Punching scene");
        }
        if (PlayerPrefs.GetInt("Level") == 0)
        {
            levelType = LevelType.collision;
            print("Punching scene");
        }
    }
    private void Update()
    {
       
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void IncreaseLevel()
    {
        
        int level = PlayerPrefs.GetInt("Level")+1;
        PlayerPrefs.SetInt("Level", level);
        SceneManager.LoadScene(level);
    }
    private void OnDestroy()
    {
        FinishPoint.OnleyelTypePunching -= FinishPoint_OnleyelTypePunching;
    }
}
