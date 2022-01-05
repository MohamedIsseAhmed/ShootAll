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
      // PlayerPrefs.SetInt("Level", 0);
        currentLevel = PlayerPrefs.GetInt("Level", 0);
        FinishPoint.OnlevelTypePunching += FinishPoint_OnleyelTypePunching;
        HealthBar.OnBigGuyDestroyed += HealthBar_OnBigGuyDestroyed;
    }

    private void HealthBar_OnBigGuyDestroyed()
    {
       levelType = LevelType.collision;
    }

    private void FinishPoint_OnleyelTypePunching()
    {
        levelType = LevelType.Punching;
      
    }

    void Start()
    {
        levelType = LevelType.collision;

        if (PlayerPrefs.GetInt("Level") == 0)
        {
            levelType = LevelType.collision;
            print("collision scene");
        }

        if (PlayerPrefs.GetInt("Level") == 1)
        {
            levelType = LevelType.Punching;
            print("Punching scene");
        }
        if (PlayerPrefs.GetInt("Level") == 2)
        {
            levelType = LevelType.Punching;
            print("Punching scene");
        }
         if (PlayerPrefs.GetInt("Level") == 3)
        {
            levelType = LevelType.Punching;
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
        

        int level = PlayerPrefs.GetInt("Level") + 1;

        PlayerPrefs.SetInt("Level", level);
        int index = SceneManager.GetActiveScene().buildIndex;
      
        SceneManager.LoadScene(level);
        DontDestroyOnLoad(FindObjectOfType<Shoot>().gameObject);
    }
   
    private void OnDestroy()
    {
        print("destroying LEVEL");
        FinishPoint.OnlevelTypePunching -= FinishPoint_OnleyelTypePunching;
    }
}
