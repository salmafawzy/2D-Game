using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;
    [SerializeField] private LayerMask JumpGd;
    private float dirX;
   [SerializeField] private float moveSp = 7f;
   [SerializeField] private float jumpF = 14f;
    private enum State {idle ,run,jump,fall }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSp, rb.velocity.y);

        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
           rb.velocity = new Vector2(rb.velocity.x, jumpF);
        }

        upAnimation();
    }
    private void upAnimation()
    {
        State state;

        if (dirX > 0f)
        {
            state = State.run;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = State.run;
            sprite.flipX = true;
        }
        else
        {
            state = State.idle;
        }
        if (rb.velocity.y> .1f)
        {
            state = State.jump;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = State.fall;
        }
        anim.SetInteger("state", (int)state);
    }
    private bool IsGrounded()
    {
       return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, JumpGd);
    }
}
