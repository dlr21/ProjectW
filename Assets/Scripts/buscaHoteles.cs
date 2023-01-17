using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buscaHoteles : MonoBehaviour
{

    public Datos datos;
    public GameObject hotel;//prefab viaje
    public GameObject content;

    private GameObject aux;//auxiliar para usar viaje tras viaje

    private Vector2 v = new Vector3(0,200);

    public Hoteles hoteles;

    private void Start()
    {
        datos = GameObject.FindGameObjectWithTag("Datos").GetComponent<Datos>();
        buscadorH(datos.getViajarA());
    }

    public List<Hotel> coincidenH(Ciudad dest) {
        return datos.hotelesPosbles(dest);
    }

    //
    //SIGUIENTE TAREA
    //dejamos estos ejemplos para mover hacia arriba y hacia abajo ademas de hacer las busquedas
    //

    public void buscadorH(Ciudad dest) {

        List<Hotel> posibles =coincidenH(dest);

        for (int i = 0; i < posibles.Count; i++) {
            aux = Instantiate(hotel, content.transform) as GameObject;
            aux.GetComponent<RectTransform>().anchoredPosition = v;
            aux.GetComponent<InfoHotel>().setViaje(posibles[i]);
            hoteles.addViaje(aux);
            v.y = v.y - 500;
        }
        
    }

    public void BotonViajar()
    {
        hoteles.Viajar();
    }
    
}
