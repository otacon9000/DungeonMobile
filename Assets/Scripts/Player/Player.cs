using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    private Rigidbody2D _rb;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _jumpForce;
    [SerializeField]
    private LayerMask _groundLayer;
    private bool _resetJump = false;
    private bool _grounded;

    private PlayerAnimation _anim;
    
    public int Health { get; set; }
    [SerializeField]
    private int _gems = 0;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<PlayerAnimation>();
    }

    void Update()
    {
        Movement();
        Attack();
    }

    
    private void Movement()
    {
        float move = Input.GetAxisRaw("Horizontal");
        _anim.Move(move);
        _rb.velocity = new Vector2(move * _speed , _rb.velocity.y);
        _grounded = IsGrounded();

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded() == true)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
            _anim.Jump(true);
            StartCoroutine(ResetJumpRoutine());
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.8f, _groundLayer.value);
        if (hit.collider != null)
        {
            if (_resetJump == false)
            {
                _anim.Jump(false);
                return true;
            }
        }
       
        return false;
    }

    private void Attack()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && IsGrounded() == true)
        {
            _anim.BaseAttack();
        }
    }
    
    IEnumerator ResetJumpRoutine()
    {
        _resetJump = true;
        yield return new WaitForSeconds(0.1f);
        _resetJump = false;
    }

    
    public void Damage()
    {
        Debug.LogError("damage");
    }

    public void AddGems(int value)
    {
        _gems += value;
    }
}
