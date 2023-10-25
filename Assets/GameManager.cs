using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()                                        
    {
      if(Instance == null) Instance = this;                                             // If there is no instance of GameManager, make this the instance
      else if(Instance != this) Destroy(gameObject);                                    // If there is an instance of GameManager, destroy this instance
      
    }

    public float currentScore = 0f;                                                        // The score atm of the player set to 0 by default
    public bool isPlaying = false;

    public SaveData data;

    private void Update()
    {
        if(isPlaying)
        {
            currentScore += Time.deltaTime;                                                // Add 1 to the score every second
        }

                                                                                              /*      if(Input.GetKeyDown("k"))
                                                                                                {
                                                                                                 isPlaying = true;
                                                                                                }
                                                                                             */
    }


    public UnityEvent  onPlay = new UnityEvent();
    public UnityEvent onGameOver = new UnityEvent();


    private void Start()
    {
        string LoadedData = Save.Load("save");      
        
                                                                // Load the save data
        if (LoadedData != null)
        {                                                         // if we have save data
            data = JsonUtility.FromJson<SaveData>(LoadedData);
        }
        else                                                                             // if we have no save data to load
        {
            data = new SaveData();                                                        // Create a new save data
        }
                                                            

    }





    public void StartGame()
    {
        onPlay.Invoke();
        isPlaying = true;
        currentScore = 0;       // moved from gameover function to here so the score resets when the game starts
    }



    public void GameOver()
    {
        

        if (data.highscore < currentScore)
        { 
        data.highscore = currentScore;
         string saveString = JsonUtility.ToJson(data);
            Save.saveSystem("save", saveString);
        }


        isPlaying = false;                                                    // Reset the score to 0 afte player dies
        onGameOver.Invoke();

       // currentScore = 0;
        
    }


    public string PrettyScore()                    // return the current score                                         
    {
        return Mathf.RoundToInt(currentScore).ToString();              // the Pretty score is to roudn off, make easy to display                                                             
    }

    public string PrettyHighScore()                    // return the current score                                         
    {
        return Mathf.RoundToInt(data.highscore).ToString();              // the Pretty score is to roudn off, make easy to display                                                             
    }
}
