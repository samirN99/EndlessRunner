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


    public void StartGame()
    {
        onPlay.Invoke();
        isPlaying = true;
    }



    public void GameOver()
    {
        onGameOver.Invoke();
        currentScore = 0;
        isPlaying = false;                                                                                   // Reset the score to 0 afte player dies
    }


    public string PrettyScore()                    // return the current score                                         
    {
        return Mathf.RoundToInt(currentScore).ToString();              //roudn off, make easy to display                                                             
    }
}
