using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Datos : MonoBehaviour
{

    public List<Ciudad> ciudades;
    public List<Viaje> viajes;

    [SerializeField]private int nCiudades;

    // Awake para llamarse antes de Start en otros scripts donde se utilizan los datos
    void Awake()
    {
        ciudades = Resources.LoadAll<Ciudad>("Ciudades").ToList();
        viajes = Resources.LoadAll<Viaje>("Viajes").ToList();
    }

    public List<Viaje> viajesPosbles(Ciudad origen, Ciudad destino) {

        List<Viaje> v = new List<Viaje>();

        for (int i = 0; i < viajes.Count; i++) {
            if (viajes[i] != null)
            {
                if (viajes[i].getDestino().id == destino.id && viajes[i].getOrigen().id == origen.id)
                {
                    v.Add(viajes[i]);
                }
            }
        }

        return v;
    }

    public Ciudad ciudadAleatoria()
    {
        int a = Random.Range(0, ciudades.Count);
        Ciudad c = ciudades[a];
        return c;
    }

    public Ciudad[] rutaAleatoria() {

        Ciudad[] aux = new Ciudad[nCiudades];
        Ciudad noRep = new Ciudad();
        for (int i = 0; i < aux.Length; i++) {
            noRep= ciudadAleatoria();
            if (!pertenece(noRep, aux))
            {
                aux[i] = noRep;
            }
            else {
                i--;
            }
        }

        return aux;
    }

    public bool pertenece(Ciudad c, Ciudad[] aux) {

        for (int i = 0; i < aux.Length; i++)
        {
            if (aux[i] != null) {
                if (aux[i].id == c.id) {
                    return true;
                }
            }
        }

            return false;
    }

    public int getNCiudades() {
        return nCiudades;
    }

}
