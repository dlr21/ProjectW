using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofre : MonoBehaviour
{
    [SerializeField] private GameObject gm;
    [SerializeField] private Ciudad ciudad;

    private List<Preguntas> preguntas;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager");
        ciudad = gm.GetComponent<Global>().getViajarDesde();
        preguntas=gameObject.GetComponent<Datos>().cargarPreguntas(ciudad);
    }

    public void clicCofre() {
        Debug.Log("Clic cofre abrir preguntas");
    }

    


}
