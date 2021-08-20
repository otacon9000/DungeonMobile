using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Mathematics;
using UnityEngine;

public class SpiderAnimationEvent : MonoBehaviour
{
    
    private Spider _spider;
    
    void Start()
    {
        _spider = GetComponentInParent<Spider>();
    }
    void Fire()
    {
       
       
        _spider.Attack();
    }
}
