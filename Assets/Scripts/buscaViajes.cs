using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buscaViajes : MonoBehaviour
{

    public Datos datos;
    public GameObject viaje;//prefab viaje
    public GameObject content;

    private GameObject aux;//auxiliar para usar viaje tras viaje

    private Vector2 v = new Vector3(0,200);

    public Viajes viajes;

    private void Start()
    {
        datos = GameObject.FindGameObjectWithTag("Datos").GetComponent<Datos>();
        buscadorV(datos.getViajarDesde(), datos.getViajarA());
    }

    public List<Viaje> coincidenV(Ciudad ori, Ciudad dest) {
        return datos.viajesPosbles(ori, dest);
    }

    //
    //SIGUIENTE TAREA
    //dejamos estos ejemplos para mover hacia arriba y hacia abajo ademas de hacer las busquedas
    //

    public void buscadorV(Ciudad ori, Ciudad dest) {

        List<Viaje> posibles =coincidenV(ori, dest);

        for (int i = 0; i < posibles.Count; i++) {
            aux = Instantiate(viaje, content.transform) as GameObject;
            aux.GetComponent<RectTransform>().anchoredPosition = v;
            aux.GetComponent<InfoViaje>().setViaje(posibles[i]);
            viajes.addViaje(aux);
            v.y = v.y - 500;
        }
        
    }

    public void BotonViajar()
    {
        viajes.Viajar();
    }
    
}
