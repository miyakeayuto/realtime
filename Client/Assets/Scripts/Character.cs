//==========================================
//キャラ操作(スマホ)
//==========================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Character : MonoBehaviour
{
    float speed = 10.0f;
    Rigidbody rigidbody;
    FloatingJoystick floatingJoystickMove;
    FloatingJoystick floatingJoystickAim;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        floatingJoystickMove = GameObject.Find("Move").GetComponent<FloatingJoystick>();
        //floatingJoystickAim = GameObject.Find("Aim").GetComponent<FloatingJoystick>();
    }

    // Update is called once per frame
    void Update()
    {
        //------------
        //キャラ移動
        //------------
        //メインカメラの向きと掛けて、カメラ進行方向に対する移動量にする
        Vector3 move = (Camera.main.transform.forward * floatingJoystickMove.Vertical +
                        Camera.main.transform.right * floatingJoystickMove.Horizontal) * speed;
        move.y = rigidbody.velocity.y;
        rigidbody.velocity = move;
        //移動方向に回転
        if (move != Vector3.zero)
        {//入力されていたら
            //プレイヤーを移動方向に回転
            transform.forward = move;
            transform.forward = Vector3.Slerp(transform.forward, move, Time.deltaTime * 1.0f);
        }

        //-----------
        //弾撃ち
        //-----------


        //-----------
        //スキル
        //-----------

    }
}
