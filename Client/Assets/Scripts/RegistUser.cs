//=================================================
//ユーザー登録
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

    //名前登録ボタン
    public void OnClickRegist()
    {
        string name = "";

        //入力フィールドに入力された名前のstringのnameに代入
        name = input.text;

        //UserModelの登録関数を呼び出す
        model.RegistUserAsync(name);
    }
}
