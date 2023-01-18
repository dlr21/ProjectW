using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public string nombre;

    public int wallet;

    public int mode=1;//cada numero distinto modo de juego, afecta a wallet y...

    [Header("Gameobjects donde poner los valores")]
    public GameObject vistaWallet;
    public GameObject vistaNombre;
    
    // Start is called before the first frame update
    void Start()
    {
        wallet = 1000*mode;
        vistaWallet.GetComponent<TextMeshProUGUI>().text = wallet.ToString() + " W";
    }

    public void setNombre() {
        nombre = vistaNombre.GetComponent<TextMeshProUGUI>().text;
        vistaNombre.GetComponent<TextMeshProUGUI>().text = nombre.ToString();
    }

    public void restWallet(int r) {
         
        if (wallet - r < 0) {
            Debug.Log("Te quedaste sin dinero GAME OVER");
        }
        else
        {
            wallet = wallet - r;
        }
    }

    public void sumWallet(int r)
    {
        wallet = wallet + r;
    }



}
