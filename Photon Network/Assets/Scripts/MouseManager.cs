using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    [SerializeField] Texture2D texture2D;
    public void SetMouse(bool state)
    {
        Cursor.visible = state;
        Cursor.lockState = (CursorLockMode)Convert.ToInt32(!state);
        Cursor.SetCursor(texture2D, Vector2.zero, CursorMode.ForceSoftware);
    }
    private void Awake()
    {
        SetMouse(false);
    }
}
