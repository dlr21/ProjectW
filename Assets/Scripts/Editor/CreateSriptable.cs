using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CreateSriptable : MonoBehaviour
{

    public Ciudad c;
    public GameObject dat;
    public List<Ciudad> viajes;
    public List<Hotel> hoteles;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("createscriptable");
        viajes= dat.GetComponent<Datos>().ciudades;
        //createViajes();
        createHoteles();
    }

    /// <summary>
    /// hay que crear viajes para todos los destinos y origenes entre si
    /// </summary>
    void createViajes() {

        for (int i = 0; i < viajes.Count; i++) {
            for (int j = 0; j < viajes.Count; j++)
            {
                // MyClass is inheritant from ScriptableObject base class
                Viaje example = ScriptableObject.CreateInstance<Viaje>();
                example.setDestino(viajes[j]);
                example.setOrigen(viajes[i]);
                int pre =Random.Range(200,400)+ 25 * distancia(viajes[i], viajes[j]);
                example.setVueloPrecioDistancia(pre);
                //example.setPrecioDiario(Random.Range(5,30));
                // path has to start at "Assets"
                string path = "Assets/Resources/Viajes/";
                path += example.getOrigen().nombre+example.getDestino().nombre;
                //comprobar si existe otro con el mismo nombre
                path += ".asset";
                path = AssetDatabase.GenerateUniqueAssetPath(path);

                AssetDatabase.CreateAsset(example, path);

            }
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        EditorUtility.FocusProjectWindow();

    }

    int distancia(Ciudad c1, Ciudad c2) {

        int res =Mathf.Abs( c1.meridiano - c2.meridiano);

        if (res > 12)
        {
            res = res - 12;
            res = 12 - res;
        }

        return res;
    }

    /// <summary>
    /// hay que crear viajes para todos los destinos y origenes entre si
    /// </summary>
    void createHoteles()
    {

        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < viajes.Count; j++)
            {
                // MyClass is inheritant from ScriptableObject base class
                Hotel example = ScriptableObject.CreateInstance<Hotel>();
                example.setCiudad(viajes[j]);
                example.setHotel(viajes[j].nombre);
                int pre = Random.Range(5, 50);
                example.setPrecioDiario(Random.Range(5,30));
                // path has to start at "Assets"
                string path = "Assets/Resources/Hoteles/";
                path += example.getCiudad().nombre + j.ToString()+i.ToString();
                //comprobar si existe otro con el mismo nombre
                path += ".asset";
                path = AssetDatabase.GenerateUniqueAssetPath(path);

                AssetDatabase.CreateAsset(example, path);

            }
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        EditorUtility.FocusProjectWindow();

    }
}
