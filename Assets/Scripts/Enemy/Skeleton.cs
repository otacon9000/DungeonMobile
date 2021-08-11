using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable
{
    public int Health { get; set; }



    public override void Init()
    {
        base.Init();
        Health = base.health;
    }

    // public override void Movement()
    // {
    //     base.Movement();
    //
    //     Vector3 direction = player.transform.localPosition - transform.localPosition;
    //     
    //
    // }

    public void Damage()
    {
        
        Health--;
        
        _anim.SetTrigger("Hit");
        isHit = true;
        _anim.SetBool("InCombat", true);

        if (Health < 1)
        {
            Destroy(this.gameObject);
        }
    }
}
