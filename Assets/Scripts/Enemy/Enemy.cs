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
    protected bool isHit = false;
    protected bool isDead = false;
    protected Player player;

    protected Vector3 direction;
    public virtual void Init()
    {
        _anim = GetComponentInChildren<Animator>();
        _sprite = GetComponentInChildren<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void Start()
    {
        Init();
    }

    public virtual void Update()
    {
        if (IsIdleState() && _anim.GetBool("InCombat") == false)
        {
            return;
        }

        if (isDead == false)
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

        if (isHit == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
        }

        float distance = Vector3.Distance(transform.localPosition, player.transform.localPosition);
        
        if (distance > 2.0f)
        { 
            isHit = false;
            _anim.SetBool("InCombat", false);
        }

        direction = player.transform.localPosition - transform.localPosition;
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

        if (_anim.GetBool("InCombat") == true)
        {
            if (direction.x > 0.0f)
            {
                _sprite.flipX = false;
            }
            else
            {
                _sprite.flipX = true;
            }
        }
    }



}
