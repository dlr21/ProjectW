using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Preguntas
{
    public List<string> opciones = new List<string>();

    public string pregunta;

    public int correcta;
}


[CreateAssetMenu]
public class Examen : ScriptableObject
{

    public Ciudad ciudad;

    public List<Preguntas> preguntas=new List<Preguntas>();

}

