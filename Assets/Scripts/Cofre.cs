using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofre : MonoBehaviour
{
    [SerializeField] private GameObject gm;
    [SerializeField] private Ciudad ciudad;

    [SerializeField] private Examen examen;
    [SerializeField] private GameObject examenVisuals;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager");
        ciudad = gm.GetComponent<Global>().getViajarDesde();
        examen=gm.GetComponent<Datos>().cargarPreguntas(ciudad);
    }

    public void clicCofre() {
        EmpezarExamen();
        Debug.Log("Clic cofre abrir preguntas");
    }

    void EmpezarExamen() {
        examenVisuals.SetActive(true);
    }

    void CerrarExamen()
    {
        examenVisuals.SetActive(false);
    }


}
