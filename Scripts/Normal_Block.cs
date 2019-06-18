using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Normal_Block : MonoBehaviour {
    public Vector2 textureOffset;
    private Rigidbody2D myRigidBody;
    Vector2 fallingVector;
	// Use this for initialization
	void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();
        fallingVector = new Vector2();
        myRigidBody.velocity *= 0;
    }
	
	// Update is called once per frame
	void Update () {
        fallingVector.y = -(OffsetScroll.scrollSpeed + 0.03f);
        myRigidBody.position += fallingVector;
    }
}
