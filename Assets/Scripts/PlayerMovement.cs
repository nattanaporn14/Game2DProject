using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Playercontrols controls;
    public AudioSource audiosource;
    public AudioClip jump;
    

    float direction = 0;
    public float speed = 400;
    bool isFacingRight = true;

    public float jumForce = 5;
    bool isGrounded;
    int numberOFJump = 0;
    public Transform groundCheak;
    public LayerMask groundLayer;

    public Rigidbody2D playerRB;
    public Animator animator;

    private void Awake()
    {
        controls = new Playercontrols();
        controls.Enable();

        controls.Land.Move.performed += ctx =>
        {
            direction = ctx.ReadValue<float>();
        };

        controls.Land.Jump.performed += ctx => Jump();
    }

    

    // Update is called once per frame
    void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheak.position, 0.1f, groundLayer);
        animator .SetBool("isGrounded", isGrounded);

        playerRB.velocity = new Vector2(direction * speed * Time.fixedDeltaTime, playerRB.velocity.y);
        animator.SetFloat("speed", Mathf.Abs(direction));

        if (isFacingRight && direction < 0 || !isFacingRight && direction > 0)
            Flip();
    }

    void Flip() 
    {


        isFacingRight = !isFacingRight;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }

    void Jump() 
    {
        audiosource.PlayOneShot(jump);
        Debug.Log("Jump");
        if (isGrounded)
        {

            playerRB.velocity = new Vector2(playerRB.velocity.x, jumForce);
            numberOFJump = 0;
            numberOFJump++;
        }
        else  
        {
            if(numberOFJump == 1) 
            {
                playerRB.velocity = new Vector2(playerRB.velocity.x, jumForce);
                numberOFJump++;

            }
        
        }
    }
}
