using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Ciudad : ScriptableObject
{

    public int id;
    public string nombre;
    public string desc;
    public Vector2 position;
    public string pista;
    public bool activo=false;
    public int meridiano; //de uno en adelante para el calculo de la distancia
    public Sprite imagen;

}
