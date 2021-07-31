using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    GameObject playerObj;
    PlayerCtrl player;
    Transform playerTransform;

    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        player = playerObj.GetComponent<PlayerCtrl>();  
        playerTransform = playerObj.transform;
    }

    void LateUpdate()
    {
        MoveCamera();
    }

    void MoveCamera()
    {
        //横方向に追従
        transform.position = new Vector3(playerTransform.position.x + 3, transform.position.y,
                            transform.position.z);
    }

}
