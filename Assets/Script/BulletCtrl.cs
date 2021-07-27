using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    public GameObject impactPrefab;
    float speed = 10f;
    Rigidbody2D rd;
    private string enemyTag = "Enemy";

    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        rd.velocity = transform.right * speed;
    }

    void Update()
    {
        if (transform.position.x > 10.0f)  //弾の破棄（X軸で通り過ぎたら破棄)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //敵に当たった時の処理
        if(collision.tag == enemyTag)
        {
            //ダメージを与える
            EnemyCtrl enemy =collision.GetComponent<EnemyCtrl>();
            enemy.OnDamage();
            Instantiate(impactPrefab, transform.position, transform.rotation);
        }

        //消滅
        Destroy(gameObject);
    }
}
