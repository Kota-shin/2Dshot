using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject EnemyPrefab;
    //[Header("発生スパン")] float span = 1.0f;
    //[Header("経過時間")] float time = 0f;

    private float span; 
    private float time = 0f;

    void Start()
    {
        span = 5f;
    }
 
    void Update()
    {
        //時間計測
        time += Time.deltaTime;

        if(time > span)
        {
            //敵を生成（インスタンス化）
            GameObject enemy = Instantiate(EnemyPrefab);
            //生成した敵の座礁
            enemy.transform.position = new Vector2(2, 0);
            //時間計測の再計測
            time = 0f;
        }

    }
}
