using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _jumpForce;
    [SerializeField]
    private bool _isGrounded;
    [SerializeField]
    private LayerMask _groundLayer;
    private bool resetJumpNeeded = false;
    //jumpForce
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.8f, _groundLayer.value);
        Debug.DrawRay(transform.position, Vector2.down * 0.8f, Color.red);
        
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.name);
            if(resetJumpNeeded == false)
                _isGrounded = true;
        }

        float move = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space)&& _isGrounded == true)
        {        
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
            _isGrounded = false;
            resetJumpNeeded = true;
            StartCoroutine(ResetJumpRoutine());
        }
        _rb.velocity = new Vector2(move /** _speed * Time.deltaTime*/,_rb.velocity.y);
    }

    IEnumerator ResetJumpRoutine()
    {
        yield return new WaitForSeconds(0.1f);
        resetJumpNeeded = false;
    }

    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Ground"))
    //    {
    //        _isGrounded = true;
    //    }
    //}
    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Ground"))
    //    {
    //        _isGrounded = false;
    //    }
    //}
}
