using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puntuacion : MonoBehaviour
{

    static int puntosIniciales=10000;
    public int puntos;

    // Start is called before the first frame update
    void Start()
    {
        puntos = puntosIniciales;
    }
    
    public void nueva()
    {
        puntos = puntosIniciales;
    }

    public void preguntaCorrecta() {
        puntos += 10;
    }

    public void preguntaIncorrecta()
    {
        puntos -= 100;
    }

    public int getPuntos() {
        return puntos;
    }
}
