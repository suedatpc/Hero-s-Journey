using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class ccharacterController : MonoBehaviour
{
    public float speed = 1.0f;
    private Rigidbody2D r2d;
    private Animator _animator;
    private Vector3 charPos; 
    private SpriteRenderer _spriterenderer;
    [SerializeField] private GameObject _camera;
    
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>(); //caching r2d
        _animator = GetComponent <Animator>(); //caching _anim
        _spriterenderer = GetComponent<SpriteRenderer>(); //caching _spriterenderer so we can change n use it
        charPos = transform.position; 
    }

    private void FixedUpdate()
    {
        //r2d.velocity = new Vector2(speed , 0f);
    }

    void Update() //per frame
    {
        charPos = new Vector3(charPos.x +(Input.GetAxis("Horizontal") * speed * Time.deltaTime),charPos.y);
        transform.position = charPos;

        if(Input.GetAxis("Horizontal") == 0.0f)
        {
            _animator.SetFloat("speed" , 0.0f);
        }
        else
        {
            _animator.SetFloat("speed" , 1.0f);
        }

        if(Input.GetAxis("Horizontal") > 0.01f) //going right side
        {
            _spriterenderer.flipX = false; 
        }
        else if(Input.GetAxis("Horizontal") < -0.01f) //going left side
        {
            _spriterenderer.flipX = true;
        }


    }

    private void LateUpdate()
    {
        _camera.transform.position = new Vector3(charPos.x,charPos.y,charPos.z -1.0f); 
    }
}
