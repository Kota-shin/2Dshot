using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
    #region//インスペクターで設定する
    [Header("ヒットポイント")]public int hp = 5;
    [Header("爆破エフェクト")]public GameObject explosionPrefab;
    [Header("移動速度")] public float speed;
    [Header("画面外でも行動する")] public bool nonVisibleAct;
    [Header("重力")] private float gravity;
    #endregion

    #region//プライベート変数
    private Rigidbody2D rd = null;
    private SpriteRenderer sr = null;
    private bool rightTleftuF = false;
    #endregion

    

    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }


    void FixedUpdate()
    {
        if(sr.isVisible || nonVisibleAct)
        {
            int xVector = -1;
            if (rightTleftuF)
            {
                xVector = 1;
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            rd.velocity = new Vector2(xVector * speed, -gravity);
        }
        else
        {
            rd.Sleep();
        }
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
