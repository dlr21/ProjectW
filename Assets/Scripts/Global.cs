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

    [SerializeField] private Ciudad viajarA;
    [SerializeField] private Ciudad viajarDesde;
    

    private void Start()
    {
        //comenzar cada partida desde una ciudad distinta
        viajarDesde = gameObject.GetComponent<Datos>().ciudadAleatoria(); 
    }

    private void Update()
    {
        /*if (Input.GetMouseButtonDown(0)){
            Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }*/
    }

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

    public void Viajar(Ciudad c) {

        viajarA = c;
        SceneManager.LoadScene("Tienda");
    }

    public Ciudad getViajarA() {
        return viajarA;
    }

    public Ciudad getViajarDesde()
    {
        return viajarDesde;
    }

}
