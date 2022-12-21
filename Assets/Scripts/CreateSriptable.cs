using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CreateSriptable : MonoBehaviour
{

    public Ciudad c;
    // Start is called before the first frame update
    void Start()
    {
        create();

    }

    /// <summary>
    /// hay qu crear viajes apra todos los destinos y origenes entre si
    /// </summary>
    void create() {
        
        // MyClass is inheritant from ScriptableObject base class
        Viaje example = ScriptableObject.CreateInstance<Viaje>();
        example.setDestino(c);
        example.setOrigen(c);
        example.setVueloPrecioDistancia(5);
        // path has to start at "Assets"
        string path = "Assets/Resources/Viajes/filename.asset";
        AssetDatabase.CreateAsset(example, path);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = example;
    }
}
