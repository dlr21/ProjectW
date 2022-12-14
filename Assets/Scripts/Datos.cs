using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Datos : MonoBehaviour
{

    public List<Ciudad> ciudades;
    public List<Viaje> viajes;

    // Awake para llamarse antes de Start en otros scripts donde se utilizan los datos
    void Awake()
    {
        ciudades = Resources.LoadAll<Ciudad>("Ciudades").ToList();
        viajes = Resources.LoadAll<Viaje>("Viajes").ToList();
    }


    public Ciudad ciudadAleatoria()
    {
        int a = Random.Range(0, ciudades.Count - 1);
        Ciudad c = ciudades[a];
        return c;
    }
}
