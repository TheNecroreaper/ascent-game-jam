using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerAI : MonoBehaviour {

    public Transform groundCheck;
    public float Speed = 2.5f;
    public float jumpForce = 500f;
    private GameObject computer;
    public GameObject defaultPlatform;
    public GameObject eraser;
    Vector2 velocity;
    private Rigidbody2D rb2d;
    private bool grounded = false;
    [HideInInspector] public bool jump = true;
    float halfWorldHorizontalLength;

    // Use this for initialization
    void Start () {
        InvokeRepeating("Movement", 2.0f, 1f);
        computer = GameObject.Find("Player2");
        rb2d = GetComponent<Rigidbody2D>();
        halfWorldHorizontalLength = Camera.main.aspect * Camera.main.orthographicSize;
    }
	
	// Update is called once per frame
	void Update () {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
      
    }

    private void FixedUpdate()
    {
        rb2d.position += velocity * Time.fixedDeltaTime;

        if (transform.position.x < -halfWorldHorizontalLength)
        {
            transform.position = new Vector3(halfWorldHorizontalLength - .001f, transform.position.y, 0);
            CreateBlock(new Vector2(computer.transform.position.x - 1, computer.transform.position.y - .75f));
        }
        else if (transform.position.x > halfWorldHorizontalLength)
        {
            computer.transform.position = new Vector3(-(halfWorldHorizontalLength) + .001f, transform.position.y, 0);
            CreateBlock(new Vector2(computer.transform.position.x + 1, computer.transform.position.y - .75f));
        }

        if (jump && grounded)
        {
            rb2d.AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }
    }
    void Movement()
    {
        Vector2 move;
        bool right = (Random.value > 0.5f);
        if (right)
        {
            CreateBlock(new Vector2(computer.transform.position.x + 1.5f, computer.transform.position.y + .5f));
            move = new Vector2(1, 0);
        }
        else { 
            CreateBlock(new Vector2(computer.transform.position.x - 1.5f, computer.transform.position.y + .5f));
            move = new Vector2(-1, 0);
        }
        Instantiate(eraser, new Vector2(computer.transform.position.x, computer.transform.position.y + 1f), Quaternion.identity);
        Vector2 direction = move.normalized;
        velocity = direction * Speed;
        jump = true;
    }
    public void CreateBlock(Vector2 position)
    {
        Instantiate(defaultPlatform, position, Quaternion.identity);
    }
}
