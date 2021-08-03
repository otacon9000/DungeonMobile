using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
{
    private Animator _anim;
    private SpriteRenderer _sprite;
    private Vector3 _currentTarget;

    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _sprite = GetComponentInChildren<SpriteRenderer>();
    }

    public override void Update()
    {
        if (!IsIdleState())
        {
            Movement();
        }
    }


    private void Movement()
    {
        FlipSprite();

        if(transform.position == pointA.transform.position)
        {
            _currentTarget = pointB.transform.position;
            _anim.SetTrigger("Idle");
        }
        else if(transform.position == pointB.transform.position)
        {
            _currentTarget = pointA.transform.position;
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

