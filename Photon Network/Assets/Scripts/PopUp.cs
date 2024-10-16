using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{
    [SerializeField] Text Content;

    public void SetText(string contentText)
    {
        Content.text = contentText;
    }

    public void OnConfirm()
    {
        gameObject.SetActive(false);
    }
}
