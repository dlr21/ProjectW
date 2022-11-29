using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Toque : MonoBehaviour
{
    [SerializeField]private Vector2 posicion;
    Camera camara;
    // Start is called before the first frame update
    void Start()
    {
        camara = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount > 0 && Input.touchCount<3) {
            Touch toque = Input.GetTouch(0);
            if (toque.phase == TouchPhase.Began) {
                posicion = camara.ScreenToWorldPoint(toque.position);
                Debug.Log(posicion);
            }
        }
    }
}
