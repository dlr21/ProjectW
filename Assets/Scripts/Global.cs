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
    [SerializeField] private Datos datos;

    [Header("Gameobjects donde poner los valores")]
    public Player player;
    public GameObject vistaWallet;
    public GameObject vistaNombre;

    void getGameobjects()
    {
            codigoRuta = GameObject.FindGameObjectWithTag("codigoRuta");
            menuOpciones = GameObject.FindGameObjectWithTag("Menus/Opciones");
            menuOpciones.SetActive(false);
            datos = GameObject.FindGameObjectWithTag("Datos").GetComponent<Datos>();
            player = GameObject.FindGameObjectWithTag("Datos").GetComponent<Player>();
    }

    private void Start()
    {
        getGameobjects();
        vistaWallet.GetComponent<TextMeshProUGUI>().text = player.wallet.ToString() + " W";
    }

    public void setnombre() {
        player.setNombre(vistaNombre.GetComponent<TMP_InputField>().text); 
        vistaNombre.GetComponent<TMP_InputField>().text = player.nombre.ToString();
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
        if (gameObject.GetComponent<Rutas>().pintarRuta(t))
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
        SceneManager.LoadScene("Viaje");
    }




}
