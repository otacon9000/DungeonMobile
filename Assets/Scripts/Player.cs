using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField]
    private float _speed;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        float horizontalInput = Input.GetAxisRaw("Horizontal");

        _rb.velocity = new Vector2(horizontalInput /** _speed * Time.deltaTime*/,_rb.velocity.y);
        //using velocity 
        //add rigidbody 
        //collider 
    }
}
