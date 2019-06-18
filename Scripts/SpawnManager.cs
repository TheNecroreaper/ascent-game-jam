using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public GameObject[]  platform = new GameObject[7];

    private GameObject player;
	// Use this for initialization
	void Start () {
	}

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0) && !player.GetComponent<PlayerInventory>().EmptySelection()) { 
            Vector3 blockPlacement3d = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float xCoord = blockPlacement3d.x;
            float yCoord = blockPlacement3d.y;
            Vector2 blockPlacement2d = new Vector2(xCoord, yCoord);
            Instantiate(platform[player.GetComponent<PlayerInventory>().currentSelection], blockPlacement2d, Quaternion.identity);
            player.GetComponent<PlayerInventory>().RemoveItem(1);
        }
        

	}
}
