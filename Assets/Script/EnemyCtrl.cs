using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
    #region//インスペクターで設定する
    [Header("ヒットポイント")]public int hp = 5;
    [Header("爆破エフェクト")]public GameObject explosionPrefab;
    //[Header("移動速度")] public float speed;
    //[Header("画面外でも行動する")] public bool nonVisibleAct;
    #endregion

    #region//プライベート変数
    private Rigidbody2D rd = null;
    #endregion

    

    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        
    }

    public void OnDamage()
    {
        hp -= 1;
        if (hp <= 0)
        {
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

}
