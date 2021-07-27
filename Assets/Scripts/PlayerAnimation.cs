using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _anim;
    private SpriteRenderer _sprite;
    private void Start()
    {
        _sprite = GetComponentInChildren<SpriteRenderer>();
        _anim = GetComponentInChildren<Animator>();
        if (_anim == null)
            Debug.LogError("Animator is NULL");
    }

    public void Move(float move)
    {
        if (move > 0)
        { 
            _sprite.flipX = false; 
        }
        else if (move < 0)
            _sprite.flipX = true;

        _anim.SetFloat("Move", Mathf.Abs(move));
    }

    public void Jump(bool jump)
    {
        _anim.SetBool("Jump", jump);
    }
}
