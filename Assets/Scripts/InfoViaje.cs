using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

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

    [Header("Colors")]
    private Image bg;
    private bool select;

    // Start is called before the first frame update
    void Start()
    {

        gameManager = GameObject.FindGameObjectWithTag("GameManager");

        viajes = gameManager.GetComponent<Viajes>();
        viajes.BotonViajar();

        bg = gameObject.GetComponent<Image>();
    }

    public void Seleccion() {
        if (viajes.setViaje(v))
        {
            ColorSelect();
            Debug.Log("seleccionado " + v.infoV);
        }
    }

    public void nDiasChange()
    {
        int.TryParse(nDiasInput.GetComponent<TMP_InputField>().text, out viajes.nDias);
    }

    public void ColorSelect() {
        bg.color = new Color(Color.green.r, Color.green.g, Color.green.b,0.4f);
        nDiasInput.GetComponent<TMP_InputField>().text = "";
        select = true;
    }

    public void ColorDesSelect()
    {
        bg.color = new Color(Color.white.r, Color.white.g, Color.white.b, 0.4f);
        nDiasInput.GetComponent<TMP_InputField>().text="";
        select = false;
    }

    public void setViaje(Viaje viaje) {
        v = viaje;

        ori.GetComponent<TextMeshProUGUI>().text = v.origen.nombre;
        dest.GetComponent<TextMeshProUGUI>().text = v.getCiudad().nombre;
        infoV.GetComponent<TextMeshProUGUI>().text = v.infoV;
        precioV.GetComponent<TextMeshProUGUI>().text = v.getVueloPrecio().ToString();
        precioDias.GetComponent<TextMeshProUGUI>().text = v.precioDiario.ToString();
    }

    public void selectNdias() {
        if (!select) {
            viajes.DesSelectAll();
        }
    }

    public void noRaycast() {
        gameObject.GetComponent<Image>().raycastTarget = false;
    }

    public void siRaycast()
    {
        gameObject.GetComponent<Image>().raycastTarget = true;
    }
}
