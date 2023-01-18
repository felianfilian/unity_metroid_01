using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public SpriteRenderer spriteRenderer;

    [Header("Player Stats")]
    // dashing
    public float dashSpeed = 25f;
    public float dashTime = 0.2f;
    private float dashCounter;

    // movement
    public float moveSpeed = 8f;
    public float jumpForce = 20f;

    [Header("Player Mechanic")]
    public Animator animator;
    public Animator ballAnim;
    
    public LayerMask whatIsGround;
    public Transform groundPoint;

    [Header("Player Shot")]
    public GameObject bullet;
    public Transform shotPoint;

    [Header("Dash")]
    public SpriteRenderer afterImage;
    public float afterImageLifetime = 0.5f;
    public float afterImageTime = 0.03f;
    public float waitAfterDash = 0.5f;
    public Color afterImageColor;
    private float afterImageCounter;
    private float dashRechargeCounter;

    [Header("Ball")]
    public GameObject standing;
    public GameObject ball;
    public float waitToBall = 0.5f;
    private float ballCounter;

    [Header("Bomb")]
    public Transform bombPoint;
    public GameObject bomb;

    private bool canDoubleJump;
    private bool isGrounded;

    private new Rigidbody2D rigidbody;
    private AbilityTracker abilities;

    private void Awake()
    {
        instance = this;
    }

        private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        canDoubleJump = false;
        abilities = GetComponent<AbilityTracker>();
    }

    void Update()
    {
        if(dashRechargeCounter > 0)
        {
            dashRechargeCounter -= Time.deltaTime;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.P) && standing.activeSelf && abilities.canDash)
            {
                dashCounter = dashTime;
                ShowAfterImage();
            }
        }
        

        if(dashCounter > 0)
        {
            dashRechargeCounter = waitAfterDash;
            PlayerDash();
        } 
        else
        {
            PlayerMove();
            PlayerJump();
            if (standing.activeSelf)
            {
                PlayerShot();
            }
            else
            {
                DropBomb();
            }
            PlayerBall();
        }

    }

    public void PlayerMove()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = rigidbody.velocity.y;
        rigidbody.velocity = new Vector2(moveX * moveSpeed, moveY);

        if(moveX < 0)
        {
            transform.localScale = new Vector3(-1, 1,1);
        } else if(moveX > 0)
        {
            transform.localScale = Vector3.one;
        }
        

        animator.SetFloat("speed", Mathf.Abs(moveX));
    }

    public void PlayerJump()
    {
        isGrounded = Physics2D.OverlapCircle(groundPoint.position, 0.2f, whatIsGround);

        if(Input.GetButtonDown("Jump") && (isGrounded || (canDoubleJump && abilities.canDoubleJump)))
        {
            if(isGrounded)
            {
                canDoubleJump = true;
            } else
            {
                canDoubleJump = false;
                animator.SetTrigger("doubleJump");
            }

            rigidbody.velocity = new Vector2(rigidbody.velocity.y, jumpForce);
        }

        animator.SetBool("isGrounded", isGrounded);
    }

    public void PlayerShot()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            Instantiate(bullet, shotPoint.position, shotPoint.rotation);
            animator.SetTrigger("shotBullet");
        }
    }

    public void PlayerDash()
    {
         dashCounter -= Time.deltaTime;
         rigidbody.velocity = new Vector2(dashSpeed * transform.localScale.x, rigidbody.velocity.y);
         afterImageCounter -= Time.deltaTime;
         if (afterImageCounter <= 0)
         {
            ShowAfterImage();
         }
    }

    public void ShowAfterImage()
    {
        SpriteRenderer image = Instantiate(afterImage, transform.position, transform.rotation);
        image.sprite = spriteRenderer.sprite;
        image.transform.localScale = transform.localScale;
        //image.color = afterImageColor;
        Destroy(image.gameObject, afterImageLifetime);
        afterImageCounter = afterImageTime;
    }

    public void PlayerBall()
    {
        if(!ball.activeSelf)
        {
            if(Input.GetAxisRaw("Vertical") < -0.9f && abilities.canBall)
            {
                ballCounter -= Time.deltaTime;
                if(ballCounter <= 0)
                {
                    ball.SetActive(true);
                    standing.SetActive(false);
                }
            }
            else
            {
                ballCounter = waitToBall;
            }
        }
        else
        {
            if (Input.GetAxisRaw("Vertical") > 0.9f)
            {
                ballCounter -= Time.deltaTime;
                if (ballCounter <= 0)
                {
                    ball.SetActive(false);
                    standing.SetActive(true);
                }
            }
            else
            {
                ballCounter = waitToBall;
            }
            ballAnim.SetFloat("speed", Mathf.Abs(rigidbody.velocity.x));
        }
    }

    public void DropBomb()
    {
        if (ball.activeSelf && Input.GetKeyDown(KeyCode.O) && abilities.canBomb)
        {
            Instantiate(bomb, bombPoint.position, bombPoint.rotation);
        }
    }

}
