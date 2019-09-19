using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpSpeed = 5f;
    private float movement = 0f;
    private Rigidbody2D rigidbody;
    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    public bool isTouchingGround;
    private Animator playerAnimation;
    public Vector3 respawsPoint;
    public LevelManager gameLevelManager;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();
        respawsPoint = transform.position;
        gameLevelManager = FindObjectOfType<LevelManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);
        movement = Input.GetAxis("Horizontal");
        if (movement > 0f)
        {
            rigidbody.velocity = new Vector2(movement * speed, rigidbody.velocity.y);
            transform.localScale = new Vector2(1f, 1f);
        }
        else if(movement < 0f ){
            rigidbody.velocity = new Vector2(movement * speed, rigidbody.velocity.y);
            transform.localScale = new Vector2(-1f, 1   );
        }
        else
        {
            rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
        }

        if (Input.GetButtonDown("Jump")&& isTouchingGround)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpSpeed);

        }
        playerAnimation.SetFloat("Speed",Mathf.Abs( rigidbody.velocity.x));
        playerAnimation.SetBool("OnGround", isTouchingGround);
      
    }
     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "FallDetector")
        {
            gameLevelManager.Respawn();
        }
        if (other.tag == "CheckPoint")
        {
            respawsPoint = other.transform.position;
        }
    } 
    
}
