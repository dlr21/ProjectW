using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{

    [SerializeField] private Ciudad ciudad;

    //que sea clickable y te aparezca un desplegable para seleccionar esa ciudad como viaje, mandar a la ventana de viajes
    public void clic() {
        
    }

    public void setCiudad(Ciudad c) {
        ciudad = c;
    }

}
