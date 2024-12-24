//==================================================
//タイトル
//2024/12/24
//==================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {//画面クリックされたら
            //画面遷移
            SceneManager.LoadScene("nyuusitu");
        }
    }
}
