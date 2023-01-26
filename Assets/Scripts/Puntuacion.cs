using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puntuacion : MonoBehaviour
{
    [Header("Valores staticos")]
    [SerializeField]static int puntosIniciales=10000;
    [SerializeField] static int puntosDias = 25;
    [SerializeField] static int puntosSeg = 2;

    [Header("Valores a puntuar")]
    public int puntos;
    public int dias;
    public float tiempo;

    // Start is called before the first frame update
    void Start()
    {
        puntos = puntosIniciales;
        tiempo = 0;
    }

    private void Update()
    {
            tiempo += Time.deltaTime;
    }

    public void nueva()
    {
        puntos = puntosIniciales;
        tiempo = 0;
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

    public void masDias(int i)
    {
        dias += i;
    }

    public int getDias()
    {
        return dias;
    }

    public void diasToPuntos() {
        puntos = puntos - (dias * puntosDias);
    }

    public void tiempoToPuntos()
    {
        puntos = puntos - (Convert.ToInt32(tiempo) * puntosSeg);
    }

    public void TodoToPuntos() {
        tiempoToPuntos();
        diasToPuntos();
    }
}
