using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Cofre : MonoBehaviour
{
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

    [SerializeField] private GameObject datos;

    [Header("Booleanos")]
    public bool pRespondida;
    public bool fin;
    public bool contando;

    [Header("Temporizador")]
    public GameObject tempo;
    public float tiempoPorExamen = 60.0f;
    public float tiempo;


    // Start is called before the first frame update
    void Start()
    {
        datos = GameObject.FindGameObjectWithTag("Datos");
        ciudad = datos.GetComponent<Datos>().getViajarDesde();
        examen=datos.GetComponent<Datos>().cargarPreguntas(ciudad);
        examenVisuals.SetActive(false);
        fallo.SetActive(false);
        todasBien.SetActive(false);
        next.SetActive(false);
        tempo.SetActive(false);
        tiempo = tiempoPorExamen;
    }

    private void Update()
    {
        if (contando) {
            tiempo -= Time.deltaTime;

            tempo.GetComponent<TextMeshProUGUI>().text = "Tiempo:" + " " + FormatTime(tiempo);

            if (tiempo < 0) {
                contando = false;
                fallo.SetActive(true);
            }
        }
    }

    public string FormatTime(float time)
    {
        int minutes = (int)time / 60;
        int seconds = (int)time - 60 * minutes;
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void clicCofre() {
        empezarContador();
        EmpezarExamen();
        Debug.Log("Clic cofre abrir preguntas");
    }

    public void clicX()
    {
        if (contando) {
            pararContador();
        }
        CerrarExamen();
    }

    public void empezarContador()
    {
        tempo.SetActive(true);
        tiempo = tiempoPorExamen;
        contando = true;
        Debug.Log("empezarContador");
    }

    public void pararContador() {
        contando = false;
        Debug.Log("pararContador");
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
        tempo.SetActive(false);
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
            datos.GetComponent<Player>().getPuntuacion().preguntaCorrecta();
            //ULTIMA PREGUNTA ACERTADA
            if (examen.nPregunta >= examen.preguntas.Count-1) {
                fin = true;
                todasBien.SetActive(true);
            }
        }
        else if(!pRespondida){
            opt.GetComponent<Image>().color = new Color(Color.red.r, Color.red.g, Color.red.b, 0.4f);
            datos.GetComponent<Player>().getPuntuacion().preguntaIncorrecta();
            fallo.SetActive(true);
        }
        
    }

    public void finVolverMapa() {
        datos.GetComponent<Datos>().nextCity();
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
