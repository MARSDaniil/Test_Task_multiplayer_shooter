using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;
public class MenuManager : MonoBehaviourPunCallbacks
{

    public TMP_InputField createInput;
    public TMP_InputField joinInput;
    public TMP_InputField inputName;

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        inputName.text = PlayerPrefs.GetString("name");
        PhotonNetwork.NickName = inputName.text;
    }

    public void CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4;

        PhotonNetwork.CreateRoom(createInput.text, roomOptions);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinInput.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }
    public void SaveName()
    {
        PlayerPrefs.SetString("name", inputName.text);
        PhotonNetwork.NickName = inputName.text;
    }
}
