using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Viaje : ScriptableObject
{

    [Header("Atributos")]
    [SerializeField] private Ciudad destino;
    [SerializeField] private Ciudad origen;
    //[SerializeField]private Sprite logo;//imagen de vista en el viaje
    [SerializeField] private int precioVueloDistancia;

    public string infoV;
    public int precioDiario;
    

    public int getVueloPrecio() {
        return precioVueloDistancia;
    }

    public Ciudad getDestino() {
        return destino;
    }

    public Ciudad getOrigen()
    {
        return origen;
    }

    public void setDestino(Ciudad c)
    {
        destino=c;
    }

    public void setOrigen(Ciudad c)
    {
        origen = c; 
    }

    public void setVueloPrecioDistancia(int c)
    {
        precioVueloDistancia = c;
    }

    public void setPrecioDiario(int c)
    {
        precioDiario = c;
    }

    //[Header("Companyia")]
    //public Companya comp;
}
