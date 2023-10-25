using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{ 
   [SerializeField] private TextMeshProUGUI scoreUI;                // Reference to the score text

    GameManager gm;                                             // game manager reference

    private void Start()
    {
        gm = GameManager.Instance;                             // Get the game manager instance

    }


    private void OnGUI()
    {
        scoreUI.text = gm.PrettyScore();                      // writes the score text to the current score
    }


}
