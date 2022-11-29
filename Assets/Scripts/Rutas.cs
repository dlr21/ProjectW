using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rutas : MonoBehaviour
{
    [Header("Pin Prefab")]
    public GameObject go;

    [Header("Posibles Rutas")]
    public Ciudad[] ruta1;
    public Ciudad[] ruta2;

    [Header("Informacion de Rutas")]
    [SerializeField] private int nRutas;
    [SerializeField] public int rutaElegida;

    private void Start()
    {
        nRutas = 2;
        rutaElegida=RandomRuta();
        SelectRuta(rutaElegida);
    }

    void SelectRuta(int a) {
        if (a == 0)
        {
            PinToMap(ruta1);
        }
        else if (a == 1) {
            PinToMap(ruta2);
        }
    }

    public void PinToMap(Ciudad[] ruta)
    {
        for (int i = 0; i < ruta.Length; i++)
        {
            Instantiate(go, ruta[i].position, Quaternion.identity);
        }
    }

    public Ciudad[] CodRuta(string s)
    {
        if (s.Equals("a"))
        {
            return ruta1;
        }
        else if (s.Equals("b"))
        {
            return ruta2;
        }

        return null;
    }

    public int RandomRuta() {
        int a = Random.Range(0, nRutas);
        
        return a;
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
