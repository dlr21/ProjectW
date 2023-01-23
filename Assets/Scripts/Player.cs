using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public string nombre;

    public int wallet;
    public int puntos;
    public int mode=1;//cada numero distinto modo de juego, afecta a wallet y...

    public GameObject gameOver;
    //prefab GameObject
    public GameObject gameOverPrefab;

    [Header("Reembolso")]
    public bool correcta;
    private int reembolso;

    // Start is called before the first frame update
    void Start()
    {
        partidaNueva();
    }

    private void Update()
    {
        /*if (Input.GetKey(KeyCode.Space))
        {
            restWallet(1000);
        }*/
    }

    public void setNombre(string n) {
        nombre = n;
    }

    public bool restWallet(int r) {
         
        if (wallet - r <= 0) {
            wallet = 0;
            spawnGO();
            return false;
        }
        else
        {
            wallet = wallet - r;
            return true;
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

    public void partidaNueva() {
        wallet = 10000 * mode;
        puntos = 0;
    }

    public void setCorrecta(bool b)
    {
        correcta = b;
    }

    public bool getCorrecta()
    {
        return correcta;
    }

    public void reembolsar() { 
        sumWallet(reembolso);
    }

    public void setReembolso(int i) {
        reembolso=i;
    }

}
