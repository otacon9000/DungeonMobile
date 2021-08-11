using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidEffect : MonoBehaviour
{
    [SerializeField] private float _speed = 3.0f;

    void Start()
    {
        Destroy(this.gameObject, 5.0f);
    }
    
    void Update()
    {
        transform.Translate( Vector3.right * _speed * Time.deltaTime);
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            IDamageable hit = other.GetComponent<IDamageable>();
            if (hit != null)
            {
                hit.Damage();
                Destroy(this.gameObject);
            }
        }
    }
    
    
}
