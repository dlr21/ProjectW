using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{

    public Datos datos;
    public Player player;

    public GameObject puntos;

    private void Start()
    {
        datos = GameObject.FindGameObjectWithTag("Datos").GetComponent<Datos>();
        player = GameObject.FindGameObjectWithTag("Datos").GetComponent<Player>();
        puntos = GameObject.FindGameObjectWithTag("Puntos");
        escribirPuntuacion();
    }

    public void escribirPuntuacion() {
        player.getPuntuacion().TodoToPuntos();
        puntos.GetComponent<TextMeshProUGUI>().text = player.getPuntuacion().getPuntos().ToString();
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
