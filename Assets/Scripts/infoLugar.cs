using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class infoLugar : MonoBehaviour
{
    [Header("Informacion relevante")]
    public string message;

    [Header("GameObjects")]
    public GameObject info;
    public GameObject infoText;

    private void Start()
    {
        info.SetActive(true);
        infoText = GameObject.FindGameObjectWithTag("InfoLugar");
        info.SetActive(false);
    }


    public void OpenInfo() {
        info.SetActive(true);
        infoText.GetComponent<TextMeshProUGUI>().text = message.ToString();
    }

    public void CloseInfo()
    {
        info.SetActive(false);
    }

}
