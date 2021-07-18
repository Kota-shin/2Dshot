using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
    public int hp = 10;

    public void OnDamage()
    {
        hp -= 1;
    }

    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
