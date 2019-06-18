using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Eraser : MonoBehaviour {

    
	// Use this for initialization
	void Start () {
        
        
	}
	
	// Update is called once per frame
	void Update () {
        StartCoroutine(selfDestruct());
	}

    IEnumerator selfDestruct()
    {
        yield return new WaitForSeconds(.2f);
        Destroy(gameObject);
    }

   private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("test");
        if (collision.gameObject.layer == 12) //layer 12 is ground
        {
            Destroy(collision.gameObject);
        }
    }
        
            
    
}
