using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    #region//インスペクターで設定する
    [Header("移動速度")] public float speed;
    [Header("銃口")]public Transform shotPoint;
    [Header("弾プレファブ")] public GameObject bulletPrefab;
    [Header("右向きか")] bool isRight;
    [Header("撃った後の待機時間")]const float coolTime = 0.4f;
    [Header("接地判定")] public GroundCheck ground;
    [Header("重力")] public float gravity;
    [Header("ジャンプの速さ")] public float jumpSpeed;
    float leftCoolTime;             //待機している時間
    #endregion

    #region//プライベート変数
    private Rigidbody2D rd = null;
    private Animator animator = null;
    private string enemyTag = "Enemy";
    private string deadAreaTag = "DeadArea";
    private bool isGround = false;
    private bool isJump = false;        //お試し
    #endregion

    void Start()
    {
        //コンポーネントのインスタンスを捕まえる
        animator = GetComponent<Animator>();
        rd = GetComponent<Rigidbody2D>();      
        isRight = true;
        leftCoolTime = 0;
    }

    void Update()
    {
        isGround = ground.IsGround();
        float x = Input.GetAxis("Horizontal");
        Dierction(x);
        Shot();
    }

    void FixedUpdate()
    {
        float horizontalKey = Input.GetAxis("Horizontal");
        float ySpeed = -gravity;        //お試し
        float verticalKey = Input.GetAxis("Vertical");

        //上方向でジャンプ
        if (isGround)
        {
            if (verticalKey > 0)
            {
                ySpeed = jumpSpeed;
                isJump = true;
            }
            else
            {
                isJump = false;
            }
        }
        else if (isJump)
        {
            if (verticalKey > 0)
            {
                ySpeed = jumpSpeed;
            }
            else
            {
                isJump = false;
            }
        }
       
        //右入力で右に動く
        if (horizontalKey > 0)
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
            //rd.velocity = Vector2.zero;
            rd.velocity = new Vector2(0, rd.velocity.y);
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
        leftCoolTime -= Time.deltaTime;
        if (leftCoolTime <= 0)
        {
            if (Input.GetKeyDown("space"))      //弾を発射する処理
            {
                animator.SetTrigger("shot");    //アニメーション「shot」
                Instantiate(bulletPrefab, shotPoint.position, transform.rotation); 
                 leftCoolTime = coolTime;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == enemyTag)
        {
            Debug.Log("敵と衝突した");
        }
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == enemyTag)
        {
            Debug.Log("敵と衝突した");
        }
     }
    */
}
