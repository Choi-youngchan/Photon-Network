using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;
    [SerializeField] Vector3 direction;

    public void Movement()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.z = Input.GetAxisRaw("Vertical");

        direction.Normalize();

        transform.position += transform.TransformDirection(direction * speed * Time.deltaTime);
    }
}
