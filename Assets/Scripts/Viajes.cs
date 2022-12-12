using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Viajes : MonoBehaviour
{
    [Header("Player")]
    public GameObject gameManager;
    [SerializeField]private Player pl;

    [Header("Viaje")]
    public Viaje seleccionado;
    public int nDias;

    [Header("Viajes posibles")]
    [SerializeField] private Viaje[] viajes;

    private void Start()
    {
        pl = gameManager.GetComponent<Player>();
        nDias = -1;
        //buscar los viajes con destino el viajarA de GM, colocarlos en List

    }

    public void Viajar() {
        //get viaje

        //get dias y precio

        viajando();
        if (!seleccionado || nDias<1)
        {
            Debug.Log("NO Viajando");
        }
        else {
            Debug.Log("Viajando uouououou");
        }
       
        //SceneManager.LoadScene(seleccionado.getCiudad().nombre+"Explora");
    }

    //al confirmar el viaje con el boton viajar
    public void viajando() {

        pl.restWallet(precioViaje(seleccionado));
    }

    public int precioViaje(Viaje v) {
        int total = 0;
        if (v != null && nDias>0) {         
            total = v.precioDiario * nDias;
            total = total + v.getVueloPrecio();
        }
        Debug.Log(total);
        return total;
    }

    //al hacer clic en el post del viaje
    public bool setViaje(Viaje v) {
        if (!seleccionado)
        {
            seleccionado = v;
            return true;
        }

        seleccionado = null;
        return false;
        
    }



}
