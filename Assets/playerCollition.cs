using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCollition : MonoBehaviour
{


    private void OnCollisionEnter2D(Collision2D other)
    {
      if(other.transform.tag == "Obstacle")
        {
            Debug.Log("Collision with Obstacle detected");
            gameObject.SetActive(false);                     //game will recall this to turn back on                                     //Destroy(gameObject);
            GameManager.Instance.GameOver();
      }
    }


    private void Start()
    {
        GameManager.Instance.onPlay.AddListener(OnGameStart);
    }

    private void OnGameStart()
    {
        gameObject.SetActive(true);
    }
}
