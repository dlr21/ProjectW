using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class checkCiudad : MonoBehaviour
{

    public Player player;
    public GameObject menuIncorrecta;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Datos").GetComponent<Player>();
        menuIncorrecta = GameObject.FindGameObjectWithTag("Menus/CiudadIncorrecta");
        menuIncorrecta.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!player.getCorrecta()) {
            Debug.Log("INCoRREcta");
            menuIncorrecta.SetActive(true);
        }
    }

    public void volverMapa() {
        player.reembolsar();
        SceneManager.LoadScene("Mapa");
    }
}
