using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    #region//インスペクターで設定する
    [Header("移動速度")] public float speed;
    [Header("銃口")]public Transform shotPoint;
    [Header("弾プレファブ")] public GameObject bulletPrefab;
    Animator animator;
    [Header("右向きか")] bool isRight;
    #endregion

    #region//プライベート変数
    private Rigidbody2D rd = null;
    #endregion

    void Start()
    {
        //コンポーネントのインスタンスを捕まえる
        animator = GetComponent<Animator>();
        rd = GetComponent<Rigidbody2D>();      //Rigidbody2D
        isRight = true;
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        Dierction(x);
        Shot();
    }

    void FixedUpdate()
    {
        float horizontalKey = Input.GetAxis("Horizontal");

        //右入力で右に動く
        if(horizontalKey > 0)
        {
            rd.velocity = new Vector2(speed, rd.velocity.y);
            animator.SetBool("run", true);
        }
        //左入力で左に移動
        else if(horizontalKey < 0)
        {
            rd.velocity = new Vector2(-speed, rd.velocity.y);
            animator.SetBool("run", true);
        }
        //未入力で止まる
        else
        {
            rd.velocity = Vector2.zero;
            animator.SetBool("run", false);
        }
        
    }
   
    void Dierction(float inputX)
    {
            //右向きで左入力なら180度回転
        if(isRight && inputX < 0)
        {
            transform.Rotate(0f, 180f, 0f);
            isRight = false;
        }

            //左向きで右入力なら180度回転
        if (!isRight && inputX > 0)
        {
            transform.Rotate(0f, 180f, 0f);
            isRight = true;
        }
    }

    void Shot()
    {
        if (Input.GetKeyDown("space"))      //弾を発射する処理
        {

            animator.SetTrigger("shot");    //アニメーション「shot」
            Instantiate(bulletPrefab, shotPoint.position, transform.rotation);
        }
    }
}
