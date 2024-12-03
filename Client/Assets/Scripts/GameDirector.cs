using Shared.Interfaces.StreamingHubs;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    [SerializeField] GameObject characterPrefab;
    [SerializeField] RoomModel roomModel;
    Dictionary<Guid, GameObject> characterList = new Dictionary<Guid, GameObject>();
    [SerializeField] GameObject JoinButton;
    [SerializeField] GameObject LeaveButton;

    // Start is called before the first frame update
    async void Start()
    {
        LeaveButton.SetActive(false);
        //ユーザーが入室した時にOnJoinedUserメソッドを実行するよう、モデルに登録しておく
        roomModel.OnJoinedUser += this.OnJoinedUser;
        //接続
        await roomModel.ConnectAsync();
    }

    public async void JoinRoom()
    {
        //入室
        await roomModel.JoinAsync("sampleRoom", 1);
        //入室ボタンを非表示にして退室ボタンを表示
        JoinButton.SetActive(false);
        LeaveButton.SetActive(true);
    }

    //ユーザーが入室した時の処理
    private void OnJoinedUser(JoinedUser user)
    {
        GameObject characterObject = Instantiate(characterPrefab);      //インスタンス生成
        characterObject.transform.position = new Vector3(0,0,0);
        characterList[user.ConnectionID] = characterObject;             //フィールドで保存
    }
}
