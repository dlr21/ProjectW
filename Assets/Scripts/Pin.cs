using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{

    [SerializeField] private Ciudad ciudad;
    public bool pinClicado;
    [SerializeField] private Vector3 scalePin;
    [SerializeField] private GameObject infoCiudad;
    [SerializeField] private GameObject pinAux;

    void Start()
    {
        pinClicado = false;
        scalePin = transform.localScale;
        infoCiudad = GameObject.FindWithTag("infoCiudad");
        pinAux = GameObject.FindWithTag("pinAux");
    }

    //que sea clickable y te aparezca un desplegable para seleccionar esa ciudad como viaje, mandar a la ventana de viajes
    public void clic()
    {
        if (!pinClicado) {
            Debug.Log("clic dentro");
            pinClicado = true;
            //pin mas grande
            transform.localScale = scalePin + new Vector3(0.5f, 0.5f, 0.5f);
            //mostrar informacion de viudad
            infoCiudad.SetActive(true);
            SortinLayerPinAuxDentro();
        }
    }

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
