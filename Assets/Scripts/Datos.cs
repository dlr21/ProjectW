using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Datos : MonoBehaviour
{

    public List<Ciudad> ciudades;
    public List<Viaje> viajes;

    // Start is called before the first frame update
    void Start()
    {
        ciudades = Resources.LoadAll<Ciudad>("Ciudades").ToList();
        viajes = Resources.LoadAll<Viaje>("Viajes").ToList();
    }


    public Ciudad ciudadAleatoria()
    {
        Ciudad c = ciudades[Random.Range(0, ciudades.Count)];
        return c;
    }
}
