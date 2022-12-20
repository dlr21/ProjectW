using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class infoCiudad : MonoBehaviour
{

    public GameObject nombreCiudad;
    public GameObject descCiudad;
    public GameObject imagCiudad;

    public void activar(Ciudad c) {
        if (c) { 
            nombreCiudad.GetComponent<TextMeshProUGUI>().text = c.nombre.ToString();
            descCiudad.GetComponent<TextMeshProUGUI>().text = c.desc.ToString();
            imagCiudad.GetComponent<Image>().sprite = c.imagen;
        }
        gameObject.SetActive(true);
    }

    public void desActivar(Ciudad c)
    {
        gameObject.SetActive(false);
    }

}
