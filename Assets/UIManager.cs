using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{ 
   [SerializeField] private TextMeshProUGUI scoreUI;              //refers to:   //  score text
   [SerializeField] private GameObject startMenuUI;                              //  play button
   [SerializeField] private GameObject gameOverUI;                               // game over screen

    [SerializeField] private TextMeshProUGUI gameOverHighscoreUI;
    [SerializeField] private TextMeshProUGUI gameOverscoreUI;


    GameManager gm;                                             // game manager reference

    private void Start()
    {
        gm = GameManager.Instance;                             // Get the game manager instance
        gm.onGameOver.AddListener(ActivateGameOverUI);         // Add the game over screen to the game manager
    }

    public void PlayButtonHandler()
    {
        gm.StartGame();                                         // Start calling handler from Game Manager script when play button is pressed
      //  startMenuUI.SetActive(false);                          // Disable the play button when pressed
    }

    public void ActivateGameOverUI()
    { 
    gameOverUI.SetActive(true);                                // Activate the game over screen when player dies
        gameOverscoreUI.text = "Score: " + gm.PrettyScore();
        gameOverHighscoreUI.text = "HighScore: " + gm.PrettyHighScore();
    }
    


    private void OnGUI()
    {
        scoreUI.text = gm.PrettyScore();                      // writes the score text to the current score
    }


}
