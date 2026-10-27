using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float climbSpeed = 5f;
    Vector2 moveInput;
    Rigidbody2D rb;
    Animator myAnimator;
    CapsuleCollider2D myCollider;
    BoxCollider2D myFeetCollider;
    float gravityScaleatStart;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myCollider = GetComponent<CapsuleCollider2D>();
        myFeetCollider = GetComponent<BoxCollider2D>();
        gravityScaleatStart = rb.gravityScale;
    }

    void Update()
    {
        Run();
        FlipSprite();
        ClimbLadder();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    void OnJump(InputValue value)
    {
        if(!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) 
        {
            return; 
        }
        if (value.isPressed)
        {
            rb.linearVelocity += new Vector2(0f, jumpSpeed);
        }
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * moveSpeed, rb.linearVelocity.y);
        rb.linearVelocity = playerVelocity;
        bool hasHorizontalSpeed = Mathf.Abs(rb.linearVelocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("isRunning", hasHorizontalSpeed);
    }

    void FlipSprite()
    {
        bool hasHorizontalSpeed = Mathf.Abs(rb.linearVelocity.x) > Mathf.Epsilon;
        if (hasHorizontalSpeed) 
        {
            transform.localScale = new Vector2(Mathf.Sign(rb.linearVelocity.x), 1f);
        }
    }
    void ClimbLadder()
    {
        if (!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Climbing"))) 
        {
            rb.gravityScale = gravityScaleatStart;
            myAnimator.SetBool("isClimbing", false);
            return; 
        }
        rb.gravityScale = 0;
        Vector2 climbVelocity = new Vector2(rb.linearVelocity.x, moveInput.y * climbSpeed);
        rb.linearVelocity = climbVelocity;
        bool hasVerticalSpeed = Mathf.Abs(rb.linearVelocity.y) > Mathf.Epsilon;
        myAnimator.SetBool("isClimbing", hasVerticalSpeed);
    }
}
