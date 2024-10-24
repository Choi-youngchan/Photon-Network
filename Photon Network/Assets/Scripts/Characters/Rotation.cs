using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] float mouseX;
    [SerializeField] float mouseY;
    [SerializeField] float speed = 200.0f;
    void Start()
    {
    }

    void Update()
    {
    }
    public void InputUpdateY()
    {
        mouseX += Input.GetAxisRaw("Mouse X") * speed * Time.deltaTime;
    }

    public void RotateY(Rigidbody rigidbody)
    {
        rigidbody.transform.eulerAngles = new Vector3(0, mouseX, 0);
    }
    public void RotateX()
    {
        mouseY = Mathf.Clamp(mouseY, -65, 65);

        mouseY += Input.GetAxisRaw("Mouse Y") * speed * Time.deltaTime;

        transform.localEulerAngles = new Vector3(-mouseY, 0,0);
    }

}
