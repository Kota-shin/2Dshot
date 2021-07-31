using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTime : MonoBehaviour
{

    [Header("破壊される時間")]public float leftTime;                      //破壊されるまでの残り時間

    void Start()
    {
        Destroy(gameObject, leftTime);      //指定された時間で破壊
    }


    void Update()
    {
        
    }
}
