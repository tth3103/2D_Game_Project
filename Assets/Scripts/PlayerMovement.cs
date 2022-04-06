using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 5f;
    [SerializeField]
    private float jumpForce = 10f;
    private float movementX, movementY;
    [SerializeField]
    private Rigidbody2D myBody;
    private SpriteRenderer sr;
    private int diamondCount = 0;

    private Animator anim;
    private string WALK_ANIMATION = "Walk";
    private string JUMP_ANIMATION = "Jump";
    private bool isGrounded = true;
    private string GROUND_TAG = "Ground";

    private LifeCount lifeCount;
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        PlayerMoving();
        PlayerJumping();
        AnimatePlayer();
    }
    void PlayerMoving()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        movementY = Input.GetAxisRaw("Vertical");
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
    }
    void AnimatePlayer()
    {

        //going to the right side
        if (movementX > 0 && isGrounded)
        {
            anim.SetBool(WALK_ANIMATION, true);
            anim.SetBool(JUMP_ANIMATION, false);
            anim.SetBool("Crouch", false);
            sr.flipX = false;
        }
        //jumping to the right side
        else if (movementX > 0 && !isGrounded)
        {
            anim.SetBool(WALK_ANIMATION, false);
            anim.SetBool(JUMP_ANIMATION, true);
            anim.SetBool("Crouch", false);
            sr.flipX = false;
        }
        //going to the left side
        else if (movementX < 0 && isGrounded)
        {
            anim.SetBool(WALK_ANIMATION, true);
            anim.SetBool(JUMP_ANIMATION, false);
            anim.SetBool("Crouch", false);
            sr.flipX = true;
        }
        //jumping to the left side
        else if (movementX < 0 && !isGrounded)
        {
            anim.SetBool(WALK_ANIMATION, false);
            anim.SetBool(JUMP_ANIMATION, true);
            anim.SetBool("Crouch", false);
            sr.flipX = true;
        }
        //Normal Jumping
        else if (movementX == 0 && !isGrounded)
        {
            anim.SetBool(JUMP_ANIMATION, true);
            anim.SetBool("Crouch", false);
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
            anim.SetBool(JUMP_ANIMATION, false);
            anim.SetBool("Crouch", false);
        }
        anim.SetFloat("yVelocity",myBody.velocity.y);
        //Crouching
        if(movementY ==-1 && isGrounded && movementX == 0)
        {
            anim.SetBool("Crouch", true);
        }
    }
    void PlayerJumping()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG) || collision.gameObject.CompareTag("Platform"))
        {
            isGrounded = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Chest"))
        {
            diamondCount += Random.Range(1, 10);
            Debug.Log("Player collected " + diamondCount + " gems");
        }
        if (collision.gameObject.CompareTag("Gem"))
        {
            Destroy(collision.gameObject);
            diamondCount++;
            Debug.Log("Player collected " + diamondCount + " gems");
        }
    }
}
