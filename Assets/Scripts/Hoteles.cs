using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Hoteles : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] private Datos datos;
    [SerializeField] private Player pl;

    [Header("Hotel")]
    public GameObject botonViajar;
    public Hotel h_seleccionado;
    public int nDias;

    [Header("Hoteles posibles")]
    [SerializeField] private List<GameObject> hoteles;

    private void Start()
    {
        datos = GameObject.FindGameObjectWithTag("Datos").GetComponent<Datos>();
        pl = GameObject.FindGameObjectWithTag("Datos").GetComponent<Player>();
        nDias = -1;
    }

    public void Viajar() {
        
        if (!h_seleccionado || nDias<1)
        {
            Debug.Log("NO Viajando");
        }
        else {
            Debug.Log("Viajando uouououou");
            if (viajando()) {
                //escena de pruebas
                SceneManager.LoadScene("Alicante");
                //SceneManager.LoadScene(seleccionado.getCiudad().nombre+"Explora");
            }


        }

    }

    //al confirmar el viaje con el boton viajar
    public bool viajando() {
        return pl.restWallet(precioHotel(h_seleccionado));
    }

    public int precioHotel(Hotel v) {
   
        return v.getPrecioDiario() * nDias; 
    }

    //al hacer clic en el post del viaje
    public bool setViaje(Hotel v) {

        Hotel aux = h_seleccionado;
        //si hay viaje seleccionado desseleccionar el viaje en verde
        DesSelectAll();

        //si no hay un viaje seleccionado lo selecciono
        if (!h_seleccionado && aux!=v)
        {
            nDias = 0;
            botonViajar.SetActive(true);
            h_seleccionado = v;
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
        hoteles.Add(v);
    }

    public void DesSelectAll()
    {
        foreach (GameObject objet in hoteles)
        {
            objet.GetComponent<InfoHotel>().ColorDesSelect();
        }
        nDias = 0;
        botonViajar.SetActive(false);
        h_seleccionado = null;
    }
}
