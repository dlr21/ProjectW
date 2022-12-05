using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class nDias : MonoBehaviour
{
    [Header("Viajes")]
    public GameObject gameManager;
    public Viajes viajes;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        viajes = gameManager.GetComponent<Viajes>();
    }


    public void nDiasChange()
    {
        Debug.Log(this.gameObject.GetComponent<TMP_InputField>().text+" "+viajes.nDias);
        int.TryParse(this.gameObject.GetComponent<TMP_InputField>().text, out viajes.nDias);
        Debug.Log(this.gameObject.GetComponent<TMP_InputField>().text + " " + viajes.nDias);
    }
}
