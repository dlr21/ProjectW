using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Global : MonoBehaviour
{
    [SerializeField] private GameObject codigoRuta;
    [SerializeField] private GameObject menuOpciones;
    [SerializeField] private GameObject gameManager;

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
}
