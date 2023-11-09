using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] float movement;
    [SerializeField] public const int SPEED = 15;
    [SerializeField] bool isFacingRight = true;
    [SerializeField] const float JUMPFORCE = 500.0f;
    [SerializeField] bool jumpPressed = false;
    [SerializeField] bool isGrounded = true;

    [SerializeField] Animator animator;

    const int IDLE = 0;
    const int RUN = 1;
    const int JUMP = 2;

    // Start is called before the first frame update
    void Start()
    {
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();

        if (animator == null)
            animator = GetComponent<Animator>();

        animator.SetInteger("motion", IDLE);
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump"))
            jumpPressed = true;
    }

    //can be called potentially many times per frame -- best for physics
    void FixedUpdate()
    {
           rigid.velocity = new Vector2 (movement * SPEED, rigid.velocity.y); 
           
           if (movement < 0 && isFacingRight || movement > 0 && !isFacingRight)
           {
                Flip();
           }
           if (jumpPressed && isGrounded)
            Jump();
            else
            {
                if (isGrounded)
                {
                    if (movement > 0 || movement < 0)
                        animator.SetInteger("motion", RUN);
                    else if (movement == 0)
                        animator.SetInteger("motion", IDLE);
                }
            }
    }

    void Flip()
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }

    void Jump()
    {
        animator.SetInteger("motion", JUMP);
        rigid.velocity = new Vector2 (rigid.velocity.x, 0);
        rigid.AddForce(new Vector2 (0, JUMPFORCE));
        jumpPressed = false;
        isGrounded = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag  == "Ground")
        {
            isGrounded = true;
            jumpPressed = false;
            animator.SetInteger("motion", IDLE);
        }
    }


}
