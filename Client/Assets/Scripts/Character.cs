//==========================================
//�L��������(�X�}�z)
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
        //�L�����ړ�
        //------------
        //���C���J�����̌����Ɗ|���āA�J�����i�s�����ɑ΂���ړ��ʂɂ���
        Vector3 move = (Camera.main.transform.forward * floatingJoystickMove.Vertical +
                        Camera.main.transform.right * floatingJoystickMove.Horizontal) * speed;
        move.y = rigidbody.velocity.y;
        rigidbody.velocity = move;
        //�ړ������ɉ�]
        if (move != Vector3.zero)
        {//���͂���Ă�����
            //�v���C���[���ړ������ɉ�]
            transform.forward = move;
            transform.forward = Vector3.Slerp(transform.forward, move, Time.deltaTime * 1.0f);
        }

        //-----------
        //�e����
        //-----------


        //-----------
        //�X�L��
        //-----------

    }
}
