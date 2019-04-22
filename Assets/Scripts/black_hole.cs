using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class black_hole : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9) //set to player layer
        {
            GameController.winner = collision.gameObject.name;
            if (GameController.winner.Equals("Player1")){
                GameController.winner = "Player2";
            }
            else
                GameController.winner = "Player1";
            Debug.Log(GameController.winner);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
            Destroy(collision.gameObject);
    }
}
