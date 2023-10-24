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
            Destroy(gameObject);
            GameManager.Instance.GameOver();
      }
    }
}
