﻿using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
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
        if (isDead == true)
            return;
        Health--;
        
        _anim.SetTrigger("Hit");
        isHit = true;
        _anim.SetBool("InCombat", true);

        if (Health < 1)
        {
        
            isDead = true;    
            _anim.SetTrigger("Death");
            GameObject diamond = Instantiate(diamondPrefab, transform.position, Quaternion.identity) as GameObject;
            diamond.GetComponent<Diamond>()._gems = base.gems;
            //Destroy(this.gameObject, 2f);
        }
    }

}
