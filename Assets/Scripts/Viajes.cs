using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Viajes : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] private Datos datos;
    [SerializeField] private Player pl;

    [Header("Viaje")]
    public GameObject botonViajar;
    public Viaje v_seleccionado;
    public int nDias;

    [Header("Viajes posibles")]
    [SerializeField] private List<GameObject> viajes;

    private void Start()
    {
        datos = GameObject.FindGameObjectWithTag("Datos").GetComponent<Datos>();
        //pl = gameManager.GetComponent<Player>();
        nDias = -1;
    }

    public void Viajar() {
        //get viaje
        //get dias y precio

        //viajando(); activar con wallet
        if (!v_seleccionado || nDias<1)
        {
            Debug.Log("NO Viajando");
        }
        else {
            Debug.Log("Viajando uouououou");
            datos.setViajarDesde(v_seleccionado.getDestino());
            //escena de pruebas
            SceneManager.LoadScene("Alicante");
            //SceneManager.LoadScene(seleccionado.getCiudad().nombre+"Explora");
        }

    }

    //al confirmar el viaje con el boton viajar
    public void viajando() {
        pl.restWallet(precioViaje(v_seleccionado));
    }

    public int precioViaje(Viaje v) {
        int total = 0;
        if (v != null && nDias>0) {         
            total = v.precioDiario * nDias;
            total = total + v.getVueloPrecio();
        }
        return total;
    }

    //al hacer clic en el post del viaje
    public bool setViaje(Viaje v) {

        Viaje aux = v_seleccionado;
        //si hay viaje seleccionado desseleccionar el viaje en verde
        DesSelectAll();

        //si no hay un viaje seleccionado lo selecciono
        if (!v_seleccionado && aux!=v)
        {
            nDias = 0;
            botonViajar.SetActive(true);
            v_seleccionado = v;
            return true;
        }
        
        return false;
        
    }

    public void BotonViajar() {
        if (!botonViajar)
        {
            botonViajar = GameObject.FindGameObjectWithTag("BotonViajar");
            botonViajar.SetActive(false);
        }
    }

    public void addViaje(GameObject v) {
        viajes.Add(v);
    }

    public void DesSelectAll()
    {
        foreach (GameObject objet in viajes)
        {
            objet.GetComponent<InfoViaje>().ColorDesSelect();
        }
        nDias = 0;
        botonViajar.SetActive(false);
        v_seleccionado = null;
    }
}
