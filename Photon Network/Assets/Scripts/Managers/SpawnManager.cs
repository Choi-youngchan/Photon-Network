using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class SpawnManager : MonoBehaviourPunCallbacks
{
    [SerializeField] Transform spawnPosition;
    WaitForSeconds waitForSeconds = new WaitForSeconds(5.0f);
    void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            StartCoroutine(CreateUnit());
        }
    }
    public IEnumerator CreateUnit()
    {
        while (true) 
        {
            PhotonNetwork.InstantiateRoomObject("Rake", spawnPosition.position, Quaternion.identity);
            yield return waitForSeconds;
        }
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        PhotonNetwork.SetMasterClient(PhotonNetwork.PlayerList[0]);

        if (PhotonNetwork.IsMasterClient)
        {
            StartCoroutine(CreateUnit());
        }
    }
}
