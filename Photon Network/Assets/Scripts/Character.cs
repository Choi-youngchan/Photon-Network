using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(Move))]
[RequireComponent(typeof(Rotation))]

public class Character : MonoBehaviourPunCallbacks
{
    [SerializeField] Camera remoteCamera;
    [SerializeField] Rotation rotation;
    Move move;
    // Start is called before the first frame update
    private void Awake()
    {
        move = GetComponent<Move>();

        rotation = GetComponent<Rotation>();
    }
    void Start()
    {
       DisableCamera();
    }

    void Update()
    {
        move.Movement();

        rotation.RotateY();
    }
    public void DisableCamera()
    {
        // 현재 플레이어가 나 자신이라면
        if(photonView.IsMine)
        {
            Camera.main.gameObject.SetActive(false);
        }
        else
        {
            remoteCamera.gameObject.SetActive(false);
        }
    }
}
