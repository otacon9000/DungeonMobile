using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy
{
    private Vector3 _currentTarget;
    private Animator _anim;
    private SpriteRenderer _sprite;

    void Start()
    {     
        _sprite = GetComponentInChildren<SpriteRenderer>();
        _anim = GetComponentInChildren<Animator>();
    }
    public override void Update()
    {
        if (IsIdleState())
        {
            return;
        }
        Movement();

    }

    void Movement()
    {
        FlipSprite();

        if (transform.position == pointA.position)
        {
            
            _currentTarget = pointB.position;
            _anim.SetTrigger("Idle");

        }
        else if(transform.position == pointB.position)
        {
            _currentTarget = pointA.position;
            _anim.SetTrigger("Idle");

        }
       
        transform.position = Vector3.MoveTowards(transform.position, _currentTarget, speed * Time.deltaTime);
    }



    private bool IsIdleState() 
    {  
        return _anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"); 
    }

    private void FlipSprite()
    {
        if (_currentTarget == pointA.position)
        {
            _sprite.flipX = true;
        }
        else
        {
            _sprite.flipX = false;
        }
    }
}
