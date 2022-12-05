using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Viaje : ScriptableObject
{

    [Header("Atributos")]
    [SerializeField]private Ciudad destino;
    //[SerializeField]private Sprite logo;//imagen de vista en el viaje
    [SerializeField]private int precioVueloDistancia;
    [SerializeField] public int precioDiario;
    public Ciudad origen;

    public int getVueloPrecio() {
        int tot = 0;

        //distancia origen destino, mapa separado en partes y depende de en que parte este es la distancia
        int distancia = destino.meridiano - origen.meridiano;
        distancia = Mathf.Abs(distancia);

        tot = precioVueloDistancia * distancia;

        return tot;
    }

    public Ciudad getCiudad() {
        return destino;
    }

    //[Header("Companyia")]
    //public Companya comp;
}
