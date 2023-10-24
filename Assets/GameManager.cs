using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        if(Input.GetKeyDown("k"))
        {
            isPlaying = true;
        }
    }





    public void GameOver()
    {
        currentScore = 0f;
        isPlaying = false;                                                                                   // Reset the score to 0 afte player dies
    }


    public string PrettyScore()                    // return the current score                                         
    {
        return Mathf.RoundToInt(currentScore).ToString();              //roudn off, make easy to display                                                             
    }
}
