using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public string nombre;

    public int wallet;

    [Header("Gameobjects donde poner los valores")]
    public GameObject vistaWallet;
    public GameObject vistaNombre;



    // Start is called before the first frame update
    void Start()
    {
        wallet = 1000;
        vistaWallet.GetComponent<TextMeshProUGUI>().text = wallet.ToString() + " W";
    }

    private void Update()
    {
        /*if (Input.GetMouseButtonDown(0)){
            restWallet(50);
        }*/
    }

    public void setNombre() {
        nombre = vistaNombre.GetComponent<TextMeshProUGUI>().text;
        vistaNombre.GetComponent<TextMeshProUGUI>().text = nombre.ToString();
    }

    public void restWallet(int r) {
        wallet = wallet - r;
        vistaWallet.GetComponent<TextMeshProUGUI>().text = wallet.ToString() + " W";
    }

    public void sumWallet(int r)
    {
        wallet = wallet + r;
        vistaWallet.GetComponent<TextMeshProUGUI>().text = wallet.ToString()+" W";
    }
}
