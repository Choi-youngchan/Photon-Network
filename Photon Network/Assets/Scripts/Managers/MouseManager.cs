using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseManager : MonoBehaviour
{
    [SerializeField] Texture2D texture2D;

    private static MouseManager instance;
    public static MouseManager Instance
    {
        get { return instance; }
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded; // 씬을 불러올때마다 실행되는 이벤트에 OnSceneLoaded를 등록
    }

    private void Awake()
    {
        if(instance == null) 
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        Cursor.SetCursor(texture2D, Vector2.zero, CursorMode.ForceSoftware);

    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        // if (SceneManager.GetActiveScene().buildIndex == 2)
        // {
        //     SetMouse(false);
        // }
        // else
        // {
        //     SetMouse(true);
        // }

        switch(scene.buildIndex)
        {
            case 2:SetMouse(false);
                break;
            default : SetMouse(true);
                break;
        }


    }
    public void SetMouse(bool state)
    {
        Cursor.visible = state;
        Cursor.lockState = (CursorLockMode)Convert.ToInt32(!state);
    }
}
