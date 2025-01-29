using Shared.Interfaces.StreamingHubs;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    [SerializeField] GameObject characterPrefab;
    [SerializeField] RoomModel roomModel;
    Dictionary<Guid, GameObject> characterList = new Dictionary<Guid, GameObject>();
    [SerializeField] GameObject JoinButton;
    [SerializeField] GameObject LeaveButton;
    [SerializeField] GameObject InputUserID;
    int userID;

    // Start is called before the first frame update
    async void Start()
    {
        LeaveButton.SetActive(false);

        //���[�U�[��������������OnJoinedUser���\�b�h�����s����悤�A���f���ɓo�^���Ă���
        roomModel.OnJoinedUser += this.OnJoinedUser;

        //�ڑ�
        await roomModel.ConnectAsync();
    }

    //��������
    public async void JoinRoom()
    {


        //����
        await roomModel.JoinAsync("sampleRoom", 1);
        //await roomModel.JoinAsync("sampleRoom", userID);

        //�����{�^�����\���ɂ��đގ��{�^����\��
        JoinButton.SetActive(false);
        LeaveButton.SetActive(true);
        InputUserID.SetActive(false);
    }

    //���[�U�[�������������̏���
    private void OnJoinedUser(JoinedUser user)
    {
        GameObject characterObject = Instantiate(characterPrefab);      //�C���X�^���X����
        characterObject.transform.position = new Vector3(-4, 0.1f, -30);
        characterList[user.ConnectionID] = characterObject;             //�t�B�[���h�ŕۑ�
    }
}