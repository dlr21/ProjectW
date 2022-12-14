using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buscaViajes : MonoBehaviour
{
    public GameObject gm;
    public GameObject viaje;//prefab viaje
    private GameObject aux;//auxiliar para usar viaje tras viaje
    public Viaje auxiliar;//de momento
    public Viaje auxiliar2;//de momento
    public Vector2 v = new Vector3(0,200);


    public Viajes viajes;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager");
        viajes = gm.GetComponent<Viajes>();
        buscadorV(gm.GetComponent<Global>().getViajarA(), gm.GetComponent<Global>().getViajarDesde());
    }

    //
    //SIGUIENTE TAREA
    //dejamos estos ejemplos para mover hacia arriba y hacia abajo ademas de hacer las busquedas
    //

    public void buscadorV(Ciudad ori, Ciudad dest) {
        
        aux = Instantiate(viaje, this.gameObject.transform) as GameObject;
        aux.GetComponent<RectTransform>().anchoredPosition = v;
        aux.GetComponent<InfoViaje>().setViaje(auxiliar);
        aux.transform.SetAsFirstSibling();
        viajes.addViaje(aux);
        v.y = v.y - 500;

        aux = Instantiate(viaje, this.gameObject.transform) as GameObject;
        aux.GetComponent<RectTransform>().anchoredPosition = v;
        aux.GetComponent<InfoViaje>().setViaje(auxiliar2);
        aux.transform.SetAsFirstSibling();
        viajes.addViaje(aux);
        v.y = v.y - 500;

        aux = Instantiate(viaje, this.gameObject.transform) as GameObject;
        aux.GetComponent<RectTransform>().anchoredPosition = v;
        aux.GetComponent<InfoViaje>().setViaje(auxiliar);
        aux.transform.SetAsFirstSibling();
        viajes.addViaje(aux);
        v.y = v.y - 500;

        aux = Instantiate(viaje, this.gameObject.transform) as GameObject;
        aux.GetComponent<RectTransform>().anchoredPosition = v;
        aux.GetComponent<InfoViaje>().setViaje(auxiliar2);
        aux.transform.SetAsFirstSibling();
        viajes.addViaje(aux);

    }

    public void BotonViajar()
    {
        viajes.Viajar();
    }
    
}
