using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{

    public Datos datos;

    private void Start()
    {
        datos = GameObject.FindGameObjectWithTag("Datos").GetComponent<Datos>();
    }


    public void Salir()
    {
        Debug.Log("Salir");
        Application.Quit();
    }

    public void PartidaNueva()
    {
        Debug.Log("Partida Nueva");
        datos.partidaNueva();
    }
}
