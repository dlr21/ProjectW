using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rutas : MonoBehaviour
{
    [Header("Pin Prefab")]
    public GameObject go;

    [Header("Pins Creados")]
    [SerializeField] private List<GameObject> pins=new List<GameObject>();

    [Header("Posibles Rutas")]
    public Ciudad[] ruta1;
    public Ciudad[] ruta2;

    [Header("Informacion de Rutas")]
    [SerializeField] private int nRutas;
    public int rutaElegida;

    private void Start()
    {
        nRutas = 2;
        pintarRuta();
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
            }
            else if (a == 1)
            {
                PinToMap(ruta2);
            }
        }
    }

    void pintarRuta() {
        rutaElegida = RandomRuta();
        SelectRuta(rutaElegida);
    }

    public bool pintarRuta(string s)
    {
        rutaElegida = CodRuta(s);
        if (rutaElegida == -1) return false;
        SelectRuta(rutaElegida);
        return true;
    }

    public void PinToMap(Ciudad[] ruta)
    {
        for (int i = 0; i < ruta.Length; i++)
        {
            if (go != null)
            {
                pins.Add(Instantiate(go, ruta[i].position, Quaternion.identity) as GameObject);
            }
            else {
                 Debug.Log("null pro load"); 
            }
        }
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

    public int RandomRuta() {
        int a = Random.Range(0, nRutas);
        
        return a;
    }

    public void BorrarRuta() {
        for (int i = 0; i < pins.Count; i++) {
            if (pins[i]!=null) {
                Destroy(pins[i]);
            }
        }
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

}
