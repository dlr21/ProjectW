using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lugar : MonoBehaviour
{

    public Transform posicion;
    public List<Lugar> adyacentes;

    // Start is called before the first frame update
    void Start()
    {
        posicion = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKey(KeyCode.Space))
        {
            Camera.main.transform.position = posicion.position;
            Debug.Log("nmover");
        }*/
    }

    public void moveAqui() {
        Camera.main.transform.position = posicion.position;
        Debug.Log("mover");
    }
}
