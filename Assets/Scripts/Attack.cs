using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private bool _canAttack = true;
    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamageable hit = other.GetComponent<IDamageable>();
        
        if (hit != null)
        {
            if (_canAttack == true)
            {
                _canAttack = false;
                hit.Damage();
                
                StartCoroutine(CanAttackRoutine());

            }
        }
    }

    IEnumerator CanAttackRoutine()
    {
        yield return new WaitForSeconds(0.8f);
        _canAttack = true;
    }
}
