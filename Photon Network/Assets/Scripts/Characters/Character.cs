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
    [SerializeField] Rigidbody rigidBody;
    Move move;
    // Start is called before the first frame update
    private void Awake()
    {
        move = GetComponent<Move>();

        rotation = GetComponent<Rotation>();

        rigidBody = GetComponent<Rigidbody>();
    }
    void Start()
    {
       DisableCamera();
    }

    void Update()
    {
        if (photonView.IsMine == false) return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MouseManager.Instance.SetMouse(true);
        }

        rotation.InputUpdateY();
    }
    private void FixedUpdate()
    {
        if(photonView.IsMine == false) return;

        rotation.RotateY(rigidBody);
        move.Movement(rigidBody);
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
