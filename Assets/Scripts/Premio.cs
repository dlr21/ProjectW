using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Premio : ScriptableObject
{
    public int id;
    public string nombre;
    public string desc;
    public string cod;
    public bool activo = false;
    public Sprite imagen;
}
