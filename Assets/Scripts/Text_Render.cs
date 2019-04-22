using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Text_Render : MonoBehaviour {
    
    GameController myGameController;
    TMP_Text text1;
    string winnerName;
    // Use this for initialization
    void Start () {
        text1 = gameObject.GetComponent<TMP_Text>();
        if (GameController.winner.Equals("Player1"))
            text1.text = "YOU WON";
        else
            text1.text = "JIG WON \n (He says you suck)";
    }
	
}
