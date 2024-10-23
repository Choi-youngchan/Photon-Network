using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

[RequireComponent(typeof(Rotation))]
public class Head : MonoBehaviourPunCallbacks
{
    [SerializeField] Rotation rotation;
    void Awake()
    {
        rotation = GetComponent<Rotation>();
    }

    void Update()
    {
        if (photonView.IsMine == false) return;
        rotation.RotateX();
    }
}
