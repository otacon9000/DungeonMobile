using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _playerAnim;
    private Animator _swordAnim;
    private SpriteRenderer _sprite;
    private SpriteRenderer _swordSprite;


    private void Start()
    {
        _sprite = GetComponentInChildren<SpriteRenderer>();      
        _playerAnim = GetComponentInChildren<Animator>();
        _swordSprite = transform.GetChild(1).GetComponentInChildren<SpriteRenderer>();
        _swordAnim = transform.GetChild(1).GetComponentInChildren<Animator>();

    }

    public void Move(float move)
    {
        FlipSprite(move);
        _playerAnim.SetFloat("Move", Mathf.Abs(move));
    }

    private void FlipSprite(float move)
    {
        if (move > 0)
        {
            _sprite.flipX = false;

            _swordSprite.flipX = false;
            _swordSprite.flipY = false;

            Vector3 newPos = _swordSprite.transform.localPosition;
            newPos.x = 1.01f;
            _swordSprite.transform.localPosition = newPos;
        }
        else if (move < 0)
        {
            _sprite.flipX = true;

            _swordSprite.flipX = true;
            _swordSprite.flipY = true;

            Vector3 newPos = _swordSprite.transform.localPosition;
            newPos.x = -1.01f;
            _swordSprite.transform.localPosition = newPos;
        }
    }

    public void Jump(bool jump)
    {
        _playerAnim.SetBool("Jump", jump);
    }

    public void BaseAttack()
    {
        _playerAnim.SetTrigger("Attack");
        _swordAnim.SetTrigger("SwordArc");
    }

    public void Death()
    {
        _playerAnim.SetTrigger("Death");
    }
}

