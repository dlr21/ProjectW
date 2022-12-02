using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{

    public Ciudad ciudad;
    public bool pinClicado;
    [SerializeField] private Vector3 scalePin;
    public GameObject infoCiudad;
    public GameObject pinAux;

    void Start()
    {
        pinClicado = false;
        scalePin = transform.localScale;
    }

    //que sea clickable y te aparezca un desplegable para seleccionar esa ciudad como viaje, mandar a la ventana de viajes
    public void clic()
    {
        Debug.Log("clic");
        if (!pinClicado) {
            pinClicado = true;
            //pin mas grande
            transform.localScale = scalePin + new Vector3(0.5f, 0.5f, 0.5f);
            //mostrar informacion de viudad
            infoCiudad.SetActive(true);
            SortinLayerPinAuxDentro();
        }
    }
    //por delante la pantalla para salir del pin
    void SortinLayerPinAuxDentro()
    {
        SpriteRenderer[] mesh = pinAux.gameObject.GetComponentsInChildren<SpriteRenderer>();
        for (int i = 0; i < mesh.Length; i++)
        {
            mesh[i].sortingOrder = 2;
        }
    }

    public void clicFuera() {
            pinClicado = false;
            transform.localScale = scalePin;
            infoCiudad.SetActive(false);
            SortinLayerPinAuxFuera();
    }
    //por detras la pantalla para salir del pin
    void SortinLayerPinAuxFuera()
    {
        SpriteRenderer[] mesh = pinAux.gameObject.GetComponentsInChildren<SpriteRenderer>();
        for (int i = 0; i < mesh.Length; i++)
        {
            mesh[i].sortingOrder = 0;
        }
    }

    public void setCiudad(Ciudad c) {
        ciudad = c;
    }

}
