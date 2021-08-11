using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy, IDamageable
{ 
    public int Health { get; set; }


    public override void Init()
    {
        base.Init();
        Health = base.health;
    }

    public void Damage()
    {
        Health--;
        
        _anim.SetTrigger("Hit");
        isHit = true;
        _anim.SetBool("InCombat", true);

        if (Health < 1)
        {
            isDead = true;
            _anim.SetTrigger("Death");
        }
    }

}
