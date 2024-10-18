using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class RoomManager : MonoBehaviourPunCallbacks
{
    [SerializeField] InputField roomTitleInputField;
    [SerializeField] InputField roomCapacityInputField;
    [SerializeField] Transform contentTransform;

    private Dictionary<string, RoomInfo> dictionary = new Dictionary<string, RoomInfo>();

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game Scene");
    }

    public void OnCreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();

        roomOptions.MaxPlayers = byte.Parse(roomCapacityInputField.text);
        roomOptions.IsVisible = true;
        roomOptions.IsOpen = true;

        PhotonNetwork.CreateRoom(roomTitleInputField.text, roomOptions);
    }
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        // �� ����

        // �� ������Ʈ

        // �� ����
        InstantiateRoom();
    }

    public void InstantiateRoom()
    {
        foreach(RoomInfo roominfo in dictionary.Values)
        {
            // 1. room ������Ʈ ����

            // 2. room ������Ʈ�� ��ġ���� ����

            // 3. room ������Ʈ �ȿ� �ִ� Text �Ӽ��� �����մϴ�.

            GameObject room = Instantiate(Resources.Load<GameObject>("Room"));

            room.transform.SetParent(contentTransform);

            room.GetComponent<Information>().SetData(roominfo.Name , roominfo.PlayerCount , roominfo.MaxPlayers);

        }
    }

    public void UpdateRoom()
    {

    }

    public void RemoveRoom()
    {

    }

}
