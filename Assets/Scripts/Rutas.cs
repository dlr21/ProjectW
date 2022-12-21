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
    public Ciudad[] jugando;

    [Header("Informacion de Rutas")]
    [SerializeField] private int nRutas;
    public int rutaElegida;
    [SerializeField] private int nCiudad;

    [SerializeField] private GameObject pistaText;

    private void Start()
    {
        nCiudad = 0;
        nRutas = 2;
        pintarRuta(false);//poner en true para ruta aleatoria
    }

    void pintarRuta(bool cod)
    {
        DesactivarRutas();
        if (cod)
        {
            SelectRuta(rutaElegida);
        }
        else {
            createRuta();
            rutaElegida = -1;
        }
        jugando[0].activo = true;
        Debug.Log("Activo "+ jugando[0].nombre+ jugando[0].activo);
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
            rutaElegida = a;
            if (a == 0)
            {
                PinToMap(ruta1);
                jugando = ruta1;
            }
            else if (a == 1)
            {
                PinToMap(ruta2);
                jugando = ruta2;
            }
            infoCiudad.SetActive(false);
        }
    }

    void createRuta() {
        BorrarRuta();
        rutaElegida = 99;
        aleatoria = gameObject.GetComponent<Datos>().rutaAleatoria(); //crear la ruta de 0
        PinToMap(aleatoria);
        jugando = aleatoria;
        infoCiudad.SetActive(false);
    }

    public void nextCity() {
        nCiudad++;
        //ruta aleatoria
        if (nCiudad == gameObject.GetComponent<Datos>().getNCiudades()) {
            Debug.Log("ACABASTE LA RUTA");
        }
        
    }

    //desactiva ruta 1 y 2
    void DesactivarRutas() {
        for (int i = 0; i < jugando.Length; i++) {
            jugando[i].activo = false;
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
        pintarRuta(true);
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
        primeraCiudad();
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

    private void Update()
    {
        /*if (Input.GetMouseButtonDown(0)) {

            RandomRuta();
        }
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log(rutaElegida);
        }*/
    }

    public void siguienteCiudad() {

        jugando[nCiudad].activo = false;
        nCiudad++;
        jugando[nCiudad].activo = true;

    }

    public void primeraCiudad() {
        nCiudad = 0;
    }

    public void pistaCiudad() {
        for (int i = 0; i < jugando.Length; i++) {
            if (jugando[i].activo) {
                pistaText.GetComponent<TMP_Text>().text = jugando[i].pista;
                return;
            }
        }
    }

    public void ViajarCiudad() {
        for (int i = 0; i < pins.Count; i++)
        {
            Pin p = pins[i].GetComponent<Pin>();
            if (p.pinClicado) { 
                if (p.ciudad.id == jugando[nCiudad].id)
                {
                    Debug.Log(p.ciudad);
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
