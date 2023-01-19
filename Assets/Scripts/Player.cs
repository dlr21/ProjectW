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

    public GameObject gameOver;
    //prefab GameObject
    public GameObject gameOverPrefab;

    // Start is called before the first frame update
    void Start()
    {
        wallet = 1000*mode;
        vistaWallet.GetComponent<TextMeshProUGUI>().text = wallet.ToString() + " W";
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            restWallet(1000);
        }
    }

    public void setNombre() {
        nombre = vistaNombre.GetComponent<TextMeshProUGUI>().text;
        vistaNombre.GetComponent<TextMeshProUGUI>().text = nombre.ToString();
    }

    public bool restWallet(int r) {
         
        if (wallet - r <= 0) {
            wallet = 0;
            walletText();
            spawnGO();
            return false;
        }
        else
        {
            wallet = wallet - r;
            walletText();
            return true;
        }
    }

    void walletText() {
        //asi sabemos si estamos en el mapa con el wallet visible
        if (!vistaWallet) {
            vistaWallet = GameObject.FindGameObjectWithTag("vistaWallet");
        }
        //si lo estamos escribimos
        if (vistaWallet) {
            vistaWallet.GetComponent<TextMeshProUGUI>().text = wallet.ToString() + " W";
        }
        
    }

    public void sumWallet(int r)
    {
        wallet = wallet + r;
    }

    public void spawnGO() {
        GameObject canvas = GameObject.FindGameObjectWithTag("Canvas");
        gameOver= Instantiate(gameOverPrefab, canvas.transform) as GameObject;
    }

}
