using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InfoHotel : MonoBehaviour
{

    [Header("Viaje")]
    [SerializeField] private Hotel v;
    public GameObject dest;
    public GameObject infoV;
    //public GameObject precioV;
    public GameObject precioDias;
    public GameObject nDiasInput;

    [Header("Managers")]
    [SerializeField] private Datos datos;
    public Hoteles hoteles;

    [Header("Colors")]
    private Image bg;
    private bool select;

    [Header("Content")]
    public GameObject content;
    //private bool dragContent;

    // Start is called before the first frame update
    void Start()
    {
        content = transform.parent.gameObject;

        hoteles = Camera.main.GetComponent<Hoteles>();
        hoteles.BotonViajar();

        bg = gameObject.GetComponent<Image>();
    }

    public void Seleccion() {
        Debug.Log("seleccion");
        if (hoteles.setViaje(v))
        {
            ColorSelect();
            Debug.Log("seleccionado " + v.getHotel());
        }
    }

    public void nDiasChange()
    {
        int.TryParse(nDiasInput.GetComponent<TMP_InputField>().text, out hoteles.nDias);
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

    public void setViaje(Hotel viaje)
    {
        if (viaje != null) {
            v = viaje;
            dest.GetComponent<TextMeshProUGUI>().text = v.getCiudad().nombre;
            infoV.GetComponent<TextMeshProUGUI>().text = v.getHotel();
            precioDias.GetComponent<TextMeshProUGUI>().text = v.getPrecioDiario().ToString();
        }
    }

    public void selectNdias() {
        if (!select) {
            hoteles.DesSelectAll();
        }
    }

    public void beginDrag() {
        //dragContent = true;
        Debug.Log("begin");
    }

    public void contentDrag() {
        Vector3 mouseDirection = new Vector3(0, Input.mousePosition.y, 0).normalized;
        content.transform.Translate(mouseDirection  * Time.deltaTime);
        Debug.Log("DRAG");
    }

    public void endDrag()
    {
        //dragContent = false;
        gameObject.GetComponent<Image>().raycastTarget = true;
        Debug.Log("end");
    }
}
