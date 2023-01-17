using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Datos : MonoBehaviour
{
    [Header("Resources")]
    public List<Ciudad> ciudades;
    public List<Viaje> viajes;
    public List<Examen> examenes;
    public List<Premio> premios;
    public List<Hotel> hoteles;

    [Header("Ruta jugando")]
    public Ciudad[] jugando;
    public bool nueva;
    [SerializeField] private int nCiudades;
    [SerializeField] private int nCiudad;

    [Header("Viajes")]
    [SerializeField] private Ciudad viajarA;
    [SerializeField] private Ciudad viajarDesde;

    void Awake()
    {
        nueva = true;//empieza true para tener partida nueva
        ciudades = Resources.LoadAll<Ciudad>("Ciudades").ToList();
        viajes = Resources.LoadAll<Viaje>("Viajes").ToList();
        premios = Resources.LoadAll<Premio>("Premios").ToList();
        examenes = Resources.LoadAll<Examen>("Examenes").ToList();
        hoteles = Resources.LoadAll<Hotel>("Hoteles").ToList();
        nCiudad = 0;
        //forzar resolucion
        Screen.SetResolution(1920,1080,true);
    }

    private void Start()
    {
        viajarDesde=ciudadAleatoria();
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

    public List<Hotel> hotelesPosbles(Ciudad destino)
    {

        List<Hotel> v = new List<Hotel>();

        for (int i = 0; i < hoteles.Count; i++)
        {
            if (hoteles[i] != null)
            {
                if (hoteles[i].getCiudad().id == destino.id)
                {
                    v.Add(hoteles[i]);
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

    public void rutaAleatoria() {

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

         jugando=aux;
         nueva = false;
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

    public Examen cargarPreguntas(Ciudad c) {
        for (int i = 0; i < examenes.Count; i++)
        {
            if (examenes[i].ciudad.id == c.id)
            {
                return examenes[i];
            }
        }
        Debug.Log("examen NO encontrado");
        return null;
    }

    public void nextCity()
    {
        jugando[nCiudad].activo = false;
        nCiudad++;
        //segun el numero de ciudades en cada ruta, cuidado con las customs
        if (nCiudad == gameObject.GetComponent<Datos>().getNCiudades())
        {

            Debug.Log("ACABASTE LA RUTA");
        }
        else
        {
            Debug.Log("CONTINUAMOS LA RUTA");
            //jugando[nCiudad].activo = true;
        }

    }

    public void setViajarA(Ciudad c) {
        viajarA = c;
    }

    public void setViajarDesde(Ciudad c)
    {
        viajarDesde = c;
    }

    public Ciudad getViajarA()
    {
        return viajarA;
    }

    public Ciudad getViajarDesde()
    {
        return viajarDesde;
    }

    public int getNciudad()
    {
        return nCiudad;
    }

    public void primeraCiudad() {
        nCiudad = 0;
    }
}
