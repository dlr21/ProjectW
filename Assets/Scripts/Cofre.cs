using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    [SerializeField] private GameObject next;
    [SerializeField] private GameObject fallo;
    [SerializeField] private GameObject todasBien;

    public bool pRespondida;
    public bool fin;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager");
        ciudad = gm.GetComponent<Global>().getViajarDesde();
        examen=gm.GetComponent<Datos>().cargarPreguntas(ciudad);
        examenVisuals.SetActive(false);
        fallo.SetActive(false);
        todasBien.SetActive(false);
        next.SetActive(false);
    }

    public void clicCofre() {
        EmpezarExamen();

        Debug.Log("Clic cofre abrir preguntas");
    }

    public void clicX()
    {
        CerrarExamen();
    }

    void EmpezarExamen() {
        examen.nPregunta = 0;
        pRespondida = false;
        limpiarOpciones();
        cargarPreguntas(examen.nPregunta);
        examenVisuals.SetActive(true);
    }

    void CerrarExamen()
    {
        examenVisuals.SetActive(false);
        fallo.SetActive(false);
    }

    void cargarPreguntas(int np)
    {
        if (np < examen.preguntas.Count)
        {
            nPregunta.GetComponent<TextMeshProUGUI>().text = (examen.nPregunta + 1).ToString();
            examenPregunta.GetComponent<TextMeshProUGUI>().text = examen.preguntas[np].pregunta;
            examenOpcion1.GetComponent<TextMeshProUGUI>().text = examen.preguntas[np].opciones[0];
            examenOpcion2.GetComponent<TextMeshProUGUI>().text = examen.preguntas[np].opciones[1];
            examenOpcion3.GetComponent<TextMeshProUGUI>().text = examen.preguntas[np].opciones[2];
            examenOpcion4.GetComponent<TextMeshProUGUI>().text = examen.preguntas[np].opciones[3];
        }
    }

    public void clicRespuesta(GameObject opt) {
        if (examen.preguntas[examen.nPregunta].correcta == int.Parse(opt.name))
        {
            opt.GetComponent<Image>().color = new Color(Color.green.r, Color.green.g, Color.green.b, 0.4f);
            pRespondida = true;
            next.SetActive(true);
            //ULTIMA PREGUNTA ACERTADA
            if (examen.nPregunta >= examen.preguntas.Count-1) {
                fin = true;
                todasBien.SetActive(true);
            }
        }
        else if(!pRespondida){
            opt.GetComponent<Image>().color = new Color(Color.red.r, Color.red.g, Color.red.b, 0.4f);
            fallo.SetActive(true);
        }
        
    }

    public void finVolverMapa() {
        gm.GetComponent<Rutas>().nextCity();
        SceneManager.LoadScene("Mapa");
    }

    //quitar colores
    void limpiarOpciones() {
        examenOpcion1.transform.GetChild(0).GetComponent<Image>().color = new Color(Color.white.r, Color.white.g, Color.white.b, 0f);
        examenOpcion2.transform.GetChild(0).GetComponent<Image>().color = new Color(Color.white.r, Color.white.g, Color.white.b, 0f);
        examenOpcion3.transform.GetChild(0).GetComponent<Image>().color = new Color(Color.white.r, Color.white.g, Color.white.b, 0f);
        examenOpcion4.transform.GetChild(0).GetComponent<Image>().color = new Color(Color.white.r, Color.white.g, Color.white.b, 0f);
    }

    public void nextPregunta() {
        if (pRespondida && !fin) {
            next.SetActive(false);
            examen.nPregunta++;
            cargarPreguntas(examen.nPregunta);
            limpiarOpciones();
            pRespondida = false;
        }
    }

}
