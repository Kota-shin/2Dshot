using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    float speed = 10f;
    Rigidbody2D rd;

    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        rd.velocity = transform.right * speed;
    }

 
    void Update()
    {
        
    }
}
