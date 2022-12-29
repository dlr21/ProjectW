using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Rutas : MonoBehaviour
{
    [Header("Pin Prefab")]
    public GameObject go;

    [Header("Pin Usos")]
    [SerializeField] private GameObject infoCiudad;
    [SerializeField] private GameObject pinAux;

    [Header("Pins Creados")]
    [SerializeField] private List<GameObject> pins=new List<GameObject>();

    [Header("Posibles Rutas")]
    public Ciudad[] ruta1;
    public Ciudad[] ruta2;
    public Ciudad[] aleatoria;

    [Header("Informacion de Rutas")]
    [SerializeField] private int nRutas;
    public int rutaElegida;
    

    [SerializeField] private GameObject pistaText;

    [SerializeField] private Datos datos;


    void Awake() {
        datos = GameObject.FindGameObjectWithTag("Datos").GetComponent<Datos>();
        infoCiudad = GameObject.FindGameObjectWithTag("infoCiudad");
        pinAux = GameObject.FindGameObjectWithTag("pinAux");
        pistaText = GameObject.FindGameObjectWithTag("pistaText");
    }

    //intentando que al volver al  mapa la informacion sea correcta
    void recargarRuta() {
        PinToMap(aleatoria);
        infoCiudad.SetActive(false);
        pistaCiudad();
    }

    private void Start()
    {
        rutaElegida = -1;
        nRutas = 2;
        pintarRuta(false, datos.nueva);
    }

    void pintarRuta(bool cod, bool nueva)
    {
        DesactivarRutas();
        if (cod)
        {
            SelectRuta(rutaElegida);
        }
        else
        {
            createRuta(nueva);
        }
        datos.jugando[datos.getNciudad()].activo = true;
        pistaCiudad();
    }

    public int RandomRuta()
    {
        int a = Random.Range(0, nRutas);

        return a;
    }

    void SelectRuta(int a)
    {
        if (a != -1)
        {
            BorrarRuta();
            datos.primeraCiudad();
            rutaElegida = a;
            if (a == 0)
            {
                PinToMap(ruta1);
                datos.jugando = ruta1;
            }
            else if (a == 1)
            {
                PinToMap(ruta2);
                datos.jugando = ruta2;
            }
            infoCiudad.SetActive(false);
        }
    }

    void createRuta(bool nueva) {
        BorrarRuta();
        rutaElegida = 99;
        if (nueva) {
            datos.primeraCiudad();
            datos.rutaAleatoria(); //crear la ruta de 0
        } 
        aleatoria = datos.jugando;
        PinToMap(datos.jugando);
        infoCiudad.SetActive(false);
    }

    //desactiva ruta 1 y 2
    void DesactivarRutas() {
        for (int i = 0; i < datos.jugando.Length; i++) {
            datos.jugando[i].activo = false;
        }
        infoCiudad.SetActive(true);
    }

    public void PinToMap(Ciudad[] ruta)
    {
        for (int i = 0; i < ruta.Length; i++)
        {
            if (go != null)
            {
                GameObject aux = Instantiate(go, ruta[i].position, Quaternion.identity) as GameObject;
                aux.GetComponent<Pin>().setCiudad(ruta[i]);
                aux.GetComponent<Pin>().infoCiudad = infoCiudad;
                aux.GetComponent<Pin>().pinAux = pinAux;
                pins.Add(aux);
            }
            else
            {
                Debug.Log("null pro load");
            }

        }

    }

    public void pinsDesactivar() {
        for (int i = 0; i < pins.Count; i++) {
            if (pins[i].GetComponent<Pin>().pinClicado) {
                pins[i].GetComponent<Pin>().clicFuera();
            }
        }
    }
    
    public bool pintarRuta(string s)
    {
        rutaElegida = CodRuta(s);
        if (rutaElegida == -1) return false;
        pintarRuta(true, false);
        return true;
    }

    public int CodRuta(string s)
    {
        if (s.Equals("a"))
        {
            return 0;
        }
        else if (s.Equals("b"))
        {
            return 1;
        }
        
        return -1;
    }
    
    public void BorrarRuta() {
        for (int i = pins.Count-1; i > -1; i--) {
            if (pins[i]!=null) {
                GameObject aux = pins[i];
                Destroy(aux);
                pins.RemoveAt(i);
                Debug.Log("destruido");
            }
        }
        DesactivarRutas();
    }

    public void pistaCiudad() {
        for (int i = 0; i < datos.jugando.Length; i++) {
            if (datos.jugando[i].activo) {
                pistaText.GetComponent<TMP_Text>().text = datos.jugando[i].pista;
                return;
            }
        }
    }

    public void ViajarCiudad() {
        for (int i = 0; i < pins.Count; i++)
        {
            Pin p = pins[i].GetComponent<Pin>();
            if (p.pinClicado) { 
                if (p.ciudad.id == datos.jugando[datos.getNciudad()].id)
                {
                    gameObject.GetComponent<Global>().Viajar(p.ciudad);
                    return;
                }
                else
                {
                    Debug.Log("Ciudad Erronea");
                    return;
                }
            }
        }
    }

}
