using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ccharacterController2 : MonoBehaviour
{
    public float jumpForce = 2.0f;
    public float speed = 1.0f;
    private float moveDirection;
    private bool grounded = true; //bc the hero is not jumping at the start
    private bool jump;
    private Rigidbody2D _rigidbody2D;
    private Animator anim;
    private bool moving;
    private SpriteRenderer _spriteRenderer;

    void Awake()
    {
        anim = GetComponent<Animator>(); //caching anim so we can store it in memory
    }

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>(); //caching _rigidbody2D
        _spriteRenderer = GetComponent<SpriteRenderer>(); //caching _spriterenderer
    }

    private void FixedUpdate()
    {
        if(_rigidbody2D.velocity != Vector2.zero)
        {
            moving = true;
        }
        else 
        {
            moving = false;
        }
    _rigidbody2D.velocity = new Vector2(speed*moveDirection , _rigidbody2D.velocity.y); //setting the velocity with a specified speed along the x-axis, while keeping the existing y-axis velocity unchanged

    if(jump == true)
    {
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x , jumpForce);
        jump = false;
    }

    }

    private void Update() //per frame 
    {
        if(grounded == true && (Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.D)))
        {
            if(Input.GetKey(KeyCode.A))
            {
                moveDirection = -1.0f;
                _spriteRenderer.flipX = true;
                anim.SetFloat("speed" , speed);
            }
            else if(Input.GetKey(KeyCode.D))
            {
                moveDirection = 1.0f;
                _spriteRenderer.flipX = false;
                anim.SetFloat("speed" , speed);
            }
        }
        else if(grounded == true)
        {
            moveDirection = 0.0f;
            anim.SetFloat("speed" , 0.0f);
        }

       if(grounded == true && Input.GetKey(KeyCode.W))
        {
            jump = true;
            grounded = false;
            anim.SetTrigger("jump");
            anim.SetBool("grounded" , false);
        } 
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("zemin"))
        {
            anim.SetBool("grounded" , true);
            grounded = true;
        }
    }
}

