using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl: MonoBehaviour
{
    [SerializeField] private float jumpForce;
    public float speed;
    public float smooth;
    Rigidbody2D rb2d;
    bool facingRight = true;
    public Transform GroundCheck;
    public LayerMask GroundLayer;
    private bool isGrounded;
    public float checkRadius;
    public int maxJumps;
    private int extraJumps;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        extraJumps = maxJumps;
        rb2d = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        Vector2 targetVelocity = new Vector2(x *speed, rb2d.velocity.y);

        rb2d.velocity = Vector2.SmoothDamp(rb2d.velocity, targetVelocity, ref targetVelocity, Time.deltaTime * smooth);


        // the input is moving the player right and the player is facing left...
        if (x > 0 && !facingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (x < 0 && facingRight)
        {
            // ... flip the player.
            Flip();
        }

    }
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, checkRadius, GroundLayer);

        if (rb2d.velocity.x != 0 && isGrounded)
        {
            anim.SetBool("Running", true);
        }
        else
        {
            anim.SetBool("Running", false);
        }
        if (rb2d.velocity.y != 0)
        {
            anim.SetBool("Jumping", true);
            anim.SetBool("Running", false);

        }
        else
        {
            anim.SetBool("Jumping", false);
        }
        if (isGrounded == true)
        {
            extraJumps = 1;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb2d.velocity = Vector2.up * jumpForce;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            rb2d.velocity = Vector2.up * jumpForce;
            extraJumps--;

        }


    }
    void Flip()
    {
        //Invert the facingRight variable
        facingRight = !facingRight;

        //Flip the Character
        Vector3 scale = transform.localScale;

        scale.x *= -1;

        transform.localScale = scale;
    }


}



