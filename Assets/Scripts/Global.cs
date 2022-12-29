using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Linq;

public class Global : MonoBehaviour
{
    [SerializeField] private GameObject codigoRuta;
    [SerializeField] private GameObject menuOpciones;
    [SerializeField] private GameObject gameManager;
    [SerializeField] private Datos datos;


    void getGameobjects()
    {
            codigoRuta = GameObject.FindGameObjectWithTag("codigoRuta");
            menuOpciones = GameObject.FindGameObjectWithTag("menuOpciones");
            menuOpciones.SetActive(false);
            gameManager = GameObject.FindGameObjectWithTag("GameManager");
            datos = GameObject.FindGameObjectWithTag("Datos").GetComponent<Datos>();
    }

    private void Start()
    {
        getGameobjects();
        //comenzar cada partida desde una ciudad distinta
        //if(datos.nueva)datos.ciudadAleatoria(); 
    }

    /// <summary>
    /// Menu opciones
    /// </summary>
    public void OptionButton() {
        menuOpciones.SetActive(true);
    }

    public void AtrasButton()
    {
        menuOpciones.SetActive(false);
    }

    public void CargarRutaButton()
    {
        string t = codigoRuta.GetComponent<TMP_InputField>().text;
        if (gameManager.GetComponent<Rutas>().pintarRuta(t))
        {
            menuOpciones.SetActive(false);
        }
        else {
            Debug.Log("No hay ruta con este código");
        }
    }

    //elegimos viajar a una ciudad
    public void Viajar(Ciudad c) {

        datos.setViajarA(c);
        SceneManager.LoadScene("Tienda");
    }

    void activarGO() {
        menuOpciones.SetActive(true);
    }


}
