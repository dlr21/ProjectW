using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Cofre : MonoBehaviour
{
    [SerializeField] private GameObject gm;
    [SerializeField] private Ciudad ciudad;

    [SerializeField] private Examen examen;
    [SerializeField] private GameObject examenVisuals;
    [SerializeField] private GameObject examenPregunta;
    [SerializeField] private GameObject examenOpcion1;
    [SerializeField] private GameObject examenOpcion2;
    [SerializeField] private GameObject examenOpcion3;
    [SerializeField] private GameObject examenOpcion4;
    [SerializeField] private GameObject nPregunta;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager");
        ciudad = gm.GetComponent<Global>().getViajarDesde();
        examen=gm.GetComponent<Datos>().cargarPreguntas(ciudad);
        examenVisuals.SetActive(false);
    }

    public void clicCofre() {
        EmpezarExamen();

        Debug.Log("Clic cofre abrir preguntas");
    }

    public void clicX()
    {
        CerrarExamen();
        Debug.Log("Clic x cerrar preguntas");
    }

    void EmpezarExamen() {
        examen.nPregunta = 0;
        cargarPreguntas(examen.nPregunta);
        examenVisuals.SetActive(true);
    }

    void CerrarExamen()
    {
        examenVisuals.SetActive(false);
    }

    void cargarPreguntas(int np) {
        nPregunta.GetComponent<TextMeshProUGUI>().text = (examen.nPregunta + 1).ToString(); 
        examenPregunta.GetComponent<TextMeshProUGUI>().text = examen.preguntas[np].pregunta;
        examenOpcion1.GetComponent<TextMeshProUGUI>().text = examen.preguntas[np].opciones[0];
        examenOpcion2.GetComponent<TextMeshProUGUI>().text = examen.preguntas[np].opciones[1];
        examenOpcion3.GetComponent<TextMeshProUGUI>().text = examen.preguntas[np].opciones[2];
        examenOpcion4.GetComponent<TextMeshProUGUI>().text = examen.preguntas[np].opciones[3];
    }

    public void clicRespuesta(GameObject opt) {
        if (examen.preguntas[examen.nPregunta].correcta == int.Parse(opt.name))
        {
            opt.GetComponent<Image>().color = new Color(Color.green.r, Color.green.g, Color.green.b, 0.4f);
            //activar next pregunta
        }
        else {
            opt.GetComponent<Image>().color = new Color(Color.red.r, Color.red.g, Color.red.b, 0.4f);
        }
        
    }

}
