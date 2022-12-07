using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoViaje : MonoBehaviour
{

    [Header("Viaje")]
    [SerializeField] private Viaje v;
    public GameObject ori;
    public GameObject dest;
    public GameObject infoV;
    public GameObject precioV;
    public GameObject precioDias;
    public GameObject nDiasInput;

    [Header("Managers")]
    public GameObject gameManager;
    public Viajes viajes;
    // Start is called before the first frame update
    void Start()
    {
        ori.GetComponent<TextMeshProUGUI>().text = v.origen.nombre;
        dest.GetComponent<TextMeshProUGUI>().text = v.getCiudad().nombre;
        infoV.GetComponent<TextMeshProUGUI>().text = v.infoV;
        precioV.GetComponent<TextMeshProUGUI>().text = v.getVueloPrecio().ToString();
        precioDias.GetComponent<TextMeshProUGUI>().text = v.precioDiario.ToString();

        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        viajes = gameManager.GetComponent<Viajes>();
    }

    public void Seleccion() {
        gameManager.GetComponent<Viajes>().setViaje(v);
        Debug.Log("seleccionado " + v.infoV);
    }

    public void nDiasChange()
    {
        Debug.Log(nDiasInput.GetComponent<TMP_InputField>().text + " " + viajes.nDias);
        int.TryParse(nDiasInput.GetComponent<TMP_InputField>().text, out viajes.nDias);
        Debug.Log(nDiasInput.GetComponent<TMP_InputField>().text + " " + viajes.nDias);
    }

    public void BotonViajar()
    {
        gameManager.GetComponent<Viajes>().Viajar();
    }

}
