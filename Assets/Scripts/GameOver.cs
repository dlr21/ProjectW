using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{

    public Datos datos;
    public Player player;

    private void Start()
    {
        datos = GameObject.FindGameObjectWithTag("Datos").GetComponent<Datos>();
        player = GameObject.FindGameObjectWithTag("Datos").GetComponent<Player>();
    }


    public void Salir()
    {
        Debug.Log("Salir");
        Application.Quit();
    }

    public void PartidaNueva()
    {
        Debug.Log("Partida Nueva");
        player.partidaNueva();
        datos.partidaNueva();
    }
}
