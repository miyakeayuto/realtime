using Shared.Interfaces.StreamingHubs;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    [SerializeField] GameObject characterPrefab;
    [SerializeField]RoomModel roomModel;
    Dictionary<Guid, GameObject> characterList = new Dictionary<Guid, GameObject>();

    // Start is called before the first frame update
    async void Start()
    {
        //���[�U�[��������������OnJoinedUser���\�b�h�����s����悤�A���f���ɓo�^���Ă���
        roomModel.OnJoinedUser += this.OnJoinedUser;
        //�ڑ�
        await roomModel.ConnectAsync();
    }

    public async void JoinRoom()
    {
        //����
        await roomModel.JoinAsync("sampleRoom",1);
    }

    //���[�U�[�������������̏���
    private void OnJoinedUser(JoinedUser user)
    {
        GameObject characterObject = Instantiate(characterPrefab);      //�C���X�^���X����
        characterObject.transform.position = new Vector3(0,0,0);
        characterList[user.ConnectionID] = characterObject;             //�t�B�[���h�ŕۑ�
    }
}
