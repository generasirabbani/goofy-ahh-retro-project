using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempMovementsPlayer : MonoBehaviour
{

    //Attributes

    #region numerical value
    //public
    [Header("Run")]
    public float moveSpeed;
    public float accelVal;
    public float deccelVal;
    public float velPower;
    public float frictionAmount;
    float tempSpeed;
    [Header("Jump")]
    public float jumpForce;
    public float jumpBufferTime;
    public float jumpCoyoteTime;
    public float jumpCD = 0.4f;
    public float fallGravityMultiplier;
    [Header("Dash")]
    public float dashingVelocity;
    public float dashingTime;
    public float dashCD;
    Vector2 dashingDir;
    //private
    float moveInput;
    float lastGroundedTime;
    float lastJumpTime;
    float gravityScale = 1;
    #endregion

    #region boolean value
    [Header("State")]
    public bool isGrounded;
    public bool isJumping;
    public bool isAirTime;
    public bool isDashing;
    public bool isFalling;
    public bool isAbleToDash = true;
    public bool isInvincible;
    #endregion

    #region referencing other scripts
    [Header("Reference")]
    #endregion

    #region other classes
    
    //public
    public LayerMask groundLayer;
    public Collider2D groundChecker;
    //private
    Rigidbody2D rb2d;
    
    #endregion

    void Start()
    {
        tempSpeed = moveSpeed;
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        #region groundCheck
        float extraHeight = 0.05f;
        isGrounded = Physics2D.BoxCast(groundChecker.bounds.center, groundChecker.bounds.size, 0f, Vector2.down, extraHeight, groundLayer);
        if (isGrounded)
        {
            //isJumping = false;
            lastGroundedTime = jumpCoyoteTime;
            if (!isAbleToDash)
            {
                Invoke("dashCooldown", dashCD);
            }
        }
        #endregion

        moveInput = Input.GetAxisRaw("Horizontal");
        fallGravity();
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (isAirTime)
        //{
          //  moveSpeed = tempSpeed / 2;
        //}
        //else
        //{
            //moveSpeed = tempSpeed;
        //}

        if(Mathf.Abs(rb2d.velocity.y) > 0)
        {
            isAirTime = true;
        }
        else
        {
            isAirTime = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            lastJumpTime = jumpBufferTime;
        }

        playerRun();
        if (isGrounded)
        {
            lastGroundedTime = jumpCoyoteTime;
        }
        else
        {
            lastGroundedTime -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump"))
        {
            lastJumpTime = jumpBufferTime;
        }
        else
        {
            lastJumpTime -= Time.deltaTime;
        }

        if (lastGroundedTime > 0f && lastJumpTime > 0f && !isJumping)
        {
            playerJump();
            lastJumpTime = 0f;
            isJumping = true;
            StartCoroutine(JumpCooldown());
        }
        if (Input.GetButtonUp("Jump") && rb2d.velocity.y > 0f)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y * 0.5f);

            lastJumpTime = 0f;
        }
        playerDash();
    }

    void playerRun()
    {
        float targetSpeed = moveInput * moveSpeed;
        float speedDif = targetSpeed - rb2d.velocity.x;
        float accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? accelVal : deccelVal;
        float movement = Mathf.Pow(Mathf.Abs(speedDif) * accelRate, velPower) * Mathf.Sign(speedDif);
        rb2d.AddForce(movement * Vector2.right);
        //friction
        #region frictions
        if(lastGroundedTime > 0 && Mathf.Abs(moveInput) < 0.01f)
        {
            float amount = Mathf.Min(Mathf.Abs(rb2d.velocity.x), Mathf.Abs(frictionAmount));
            amount *= Mathf.Sign(rb2d.velocity.x);
            rb2d.AddForce(Vector2.right * -amount,ForceMode2D.Impulse);
        }
        #endregion
    }

    void playerJump()
    {
        //jumpCounter--;
        rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        isJumping = true;
        isAbleToDash = true;
    }

    private IEnumerator JumpCooldown()
    {
        isJumping = true;
        yield return new WaitForSeconds(jumpCD);
        isJumping = false;
    }

    void dashCooldown()
    {
        isAbleToDash = true;
    }

    void fallGravity()
    {
        if(rb2d.velocity.y < 0)
        {
            rb2d.gravityScale = gravityScale * fallGravityMultiplier;
        }
        else
        {
            rb2d.gravityScale = gravityScale;
        }
    }

    void playerDash()
    {
        if(Input.GetButtonDown("Dash") && isAbleToDash)
        {
            isDashing = true;
            isAbleToDash = false;
            dashingDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            if(dashingDir == Vector2.zero)
            {
                dashingDir = new Vector2(transform.localScale.x, 0);
            }
            StartCoroutine(stopDashing());
        }
        if (isDashing)
        {
            Dash();
        }

    }

    void Dash()
    {
        rb2d.AddForce(dashingDir.normalized * dashingVelocity, ForceMode2D.Impulse);
        isInvincible = true;
        isJumping = false;
        return;
    }

    private IEnumerator stopDashing()
    {
        yield return new WaitForSeconds(dashingTime);
        isDashing = false;
        isInvincible = false;
        isAbleToDash = false;
    }
}
