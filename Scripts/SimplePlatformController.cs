using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlatformController : MonoBehaviour {

    [HideInInspector] public bool facingRight = true;
    [HideInInspector] public bool jump = true;

    public float moveForce = 365f;
    public float Speed = 5f;
    public float jumpForce = 1000f;
    float halfWorldHorizontalLength;
    float halfPlayerWidth;
    public Transform groundCheck;

    Vector2 velocity;
    private bool grounded = false;
    private Animator anim;
    private Rigidbody2D rb2d;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        halfPlayerWidth = transform.localScale.x / 2f;
        halfWorldHorizontalLength = Camera.main.aspect * Camera.main.orthographicSize;
    }
	
	// Update is called once per frame
	void Update () {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        Vector2 move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
        Vector2 direction = move.normalized;
        velocity = direction * Speed;

        if (Input.GetButtonDown("Jump") && grounded)
        {
            jump = true;
        }
	}

    private void FixedUpdate()
    {
        rb2d.position += velocity * Time.fixedDeltaTime;
        float h = Input.GetAxis("Horizontal");
        if (transform.position.x < -halfWorldHorizontalLength)
            transform.position = new Vector3(halfWorldHorizontalLength - .001f, transform.position.y, 0);

        else if (transform.position.x > halfWorldHorizontalLength)
            transform.position = new Vector3(-(halfWorldHorizontalLength) + .001f, transform.position.y, 0);

        if (h > 0 && !facingRight)
            Flip();
        else if (h < 0 && facingRight)
            Flip();
        
        if(jump)
        {
            anim.SetTrigger("Jump");
            rb2d.AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }
    }
    public void Slow()
    {

        StartCoroutine(PowerupDelaySlow());
        
    }
    public void SpeedUp()
    {
        StartCoroutine(PowerupDelaySpeed());

    }

    public void JumpUp()
    {
        StartCoroutine(PowerupDelayJump());

    }

    IEnumerator PowerupDelaySpeed()
    {
        Speed = 8f;
        yield return new WaitForSeconds(6f);
        Speed = 5f;
    }
    IEnumerator PowerupDelayJump()
    {
        jumpForce = 1000f;
        yield return new WaitForSeconds(6f);
        jumpForce = 500f;
    }

    IEnumerator PowerupDelaySlow()
    {
        Speed = 3f;
        yield return new WaitForSeconds(6f);
        Speed = 5f;
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
