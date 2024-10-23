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
        // 1. nickName에 inputField로 입력한 값을 저장합니다.

        // 2. PhotonNetwork.NickName에 nickName 값을 넣어줍니다.

        // 3. NickName을 저장합니다.

        // 4. 비활성화합니다.

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
