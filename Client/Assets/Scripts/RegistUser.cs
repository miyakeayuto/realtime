//=================================================
//���[�U�[�o�^
//2024/11/12
//=================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegistUser : MonoBehaviour
{
    [SerializeField] UserModel model;
    [SerializeField] InputField input;

    // Start is called before the first frame update
    void Start()
    {

    }

    //���O�o�^�{�^��
    public void OnClickRegist()
    {
        string name = "";

        //���̓t�B�[���h�ɓ��͂��ꂽ���O��string��name�ɑ��
        name = input.text;

        //UserModel�̓o�^�֐����Ăяo��
        model.RegistUserAsync(name);
    }
}
