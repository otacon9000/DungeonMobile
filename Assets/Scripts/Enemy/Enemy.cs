using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int health;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected int gems;
    [SerializeField]
    protected Transform pointA, pointB;

    protected Animator _anim;
    protected SpriteRenderer _sprite;
    protected Vector3 currentTarget;

    public virtual void Init()
    {
        _anim = GetComponentInChildren<Animator>();
        _sprite = GetComponentInChildren<SpriteRenderer>();
    }

    public void Start()
    {
        Init();
    }

    public virtual void Update()
    {
        if (!IsIdleState())
        {
            Movement();
        }
    }

    public virtual void Movement()
    {
        FlipSprite();

        if (transform.position == pointA.transform.position)
        {
            currentTarget = pointB.transform.position;
            _anim.SetTrigger("Idle");
        }
        else if (transform.position == pointB.transform.position)
        {
            currentTarget = pointA.transform.position;
            _anim.SetTrigger("Idle");
        }
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
    }


    public virtual bool IsIdleState()
    {
        return _anim.GetCurrentAnimatorStateInfo(0).IsName("Idle");
    }

    public virtual void FlipSprite()
    {
        if (currentTarget == pointA.position)
        {
            _sprite.flipX = true;
        }
        else
        {
            _sprite.flipX = false;
        }
    }



}
