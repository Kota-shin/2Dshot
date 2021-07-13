using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();   
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("攻撃");
            animator.SetTrigger("shot");
        }
    }
}
