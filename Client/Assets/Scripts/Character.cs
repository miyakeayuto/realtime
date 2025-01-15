//==========================================
//�L��������(�X�}�z)
//==========================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Character : MonoBehaviour
{
    float speed = 5.0f;
    Rigidbody rigidbody;
    FloatingJoystick floatingJoystick;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        floatingJoystick = GameObject.Find("Player(Clone)").GetComponent<FloatingJoystick>();
    }

    // Update is called once per frame
    void Update()
    {//���C���J�����̌����Ɗ|���āA�J�����i�s�����ɑ΂���ړ��ʂɂ���
        Vector3 move = (Camera.main.transform.forward * floatingJoystick.Vertical +
                        Camera.main.transform.right * floatingJoystick.Horizontal) * speed;
        move.y = rigidbody.velocity.y;
        rigidbody.velocity = move;
    }
}
