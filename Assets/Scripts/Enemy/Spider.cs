using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    public int Health { get; set; }
    [SerializeField] 
    private GameObject _acidBullet;
    
    public override void Init()
    {
        base.Init();
        Health = base.health;
    }

    public override void Movement()
    {
        //stay here
    }

    public void Damage()
    {
        Health--;
        

        if (Health < 1)
        {
            isDead = true;
            _anim.SetTrigger("Death");
        }
    }

    public void Attack()
    {
        Instantiate(_acidBullet, transform.position, Quaternion.identity);
       
    }

}

