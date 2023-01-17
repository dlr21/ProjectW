using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Hotel : ScriptableObject
{

    [Header("Atributos")]
    [SerializeField] private Ciudad ciudad;
    [SerializeField] private int precioDiario;
    //futura compañia
    [SerializeField] private string hotel;

    public void setCiudad(Ciudad c) {
        ciudad = c;
    }

    public Ciudad getCiudad()
    {
        return ciudad;
    }


    public void setHotel(string c)
    {
        hotel = c;
    }

    public string getHotel()
    {
        return hotel;
    }


    public void setPrecioDiario(int c)
    {
        precioDiario = c;
    }

    public int getPrecioDiario()
    {
        return precioDiario;
    }

}
