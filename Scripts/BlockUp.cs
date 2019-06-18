using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockUp : MonoBehaviour {

    public GameObject Text1;
    public GameObject Text2;

    // Use this for initialization
    void Start () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            Destroy(gameObject);
            if (collision.gameObject.name.Equals("Player1"))
            {
                GameObject.Find("Player1").GetComponent<PlayerInventory>().AddItem(0);
            }
                
        }

    }

    void Pickup()
    {
        Debug.Log("PowerUp");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
