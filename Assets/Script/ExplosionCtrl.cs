using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionCtrl : MonoBehaviour
{

    void Start()
    {
        var particleaSystem = GetComponent<ParticleSystem>();
        Destroy(gameObject, particleaSystem.main.duration);
    }


    void Update()
    {
        
    }
}
