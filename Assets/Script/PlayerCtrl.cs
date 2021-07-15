using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public Transform shotPoint;
    public GameObject bulletPrefab;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();   
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))      //弾を発射する処理
        {
            
            animator.SetTrigger("shot");    //アニメーション「shot」
            Instantiate(bulletPrefab, shotPoint.position,transform.rotation);
        }
    }
}
