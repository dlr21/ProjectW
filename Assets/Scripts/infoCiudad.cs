using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class infoCiudad : MonoBehaviour
{

    public GameObject nombreCiudad;
    public GameObject descCiudad;

    public void activar(Ciudad c) {
        if(nombreCiudad)nombreCiudad.GetComponent<TextMeshProUGUI>().text = c.nombre.ToString();
        descCiudad.GetComponent<TextMeshProUGUI>().text = c.desc.ToString();
        gameObject.SetActive(true);
    }

    public void desActivar(Ciudad c)
    {
        gameObject.SetActive(false);
    }

}
