using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;


public class NickName : MonoBehaviourPunCallbacks
{
    [SerializeField] string nickName;
    [SerializeField] InputField inputField;
    [SerializeField] Button button;

    public void SetName()
    {
        // 1. nickName�� inputField�� �Է��� ���� �����մϴ�.

        // 2. PhotonNetwork.NickName�� nickName ���� �־��ݴϴ�.

        // 3. NickName�� �����մϴ�.

        // 4. ��Ȱ��ȭ�մϴ�.

        nickName = inputField.text;

        PhotonNetwork.NickName = nickName;

        PlayerPrefs.SetString("NickName", PhotonNetwork.NickName);

        gameObject.SetActive(false);
    }

    void Update()
    {
        if(inputField.text.Length <= 0)
        {
            button.interactable = false;
        }
        else
        {
            button.interactable = true;
        }
    }
}
