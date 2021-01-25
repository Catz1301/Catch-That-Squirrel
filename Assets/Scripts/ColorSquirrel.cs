using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSquirrel : MonoBehaviour
{
    public GameObject squirrel;
    
    // Start is called before the first frame update
    void Start()
    {
        
        var squirrelRenderer = squirrel.GetComponent<Renderer>();
        squirrelRenderer.material.SetColor("_Color", Color.red);
        var squirrelBodyPartRenderer = squirrel.GetComponentsInChildren<Renderer>();

        System.Random rnd = new System.Random((int)System.DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());

        Color squirrelColor = new Color();

        Color Brown = new Color(139, 69, 19);
        Color Indigo = new Color(75, 0, 30);

        int color = rnd.Next(0, 3);
        if (color == 0) {
            squirrelColor = Color.red;
        }
        else if (color == 1) {
            squirrelColor = Brown;
        }
        else if (color == 2) {
            squirrelColor = Indigo;
        }

        for (int i = 0; i < squirrelBodyPartRenderer.Length; i++) {
            squirrelBodyPartRenderer[i].material.SetColor("_Color", squirrelColor);
        }

        //Debug.Log(squirrelRenderer);

        //Debug.Log("Squirrel Body Part Components:");
        /*for (int i = 0; i < squirrelBodyPartRenderer.Length; i++) {
            Debug.Log("squirrelBodyPartRenderer[" + i.ToString() + "].name:" + squirrelBodyPartRenderer[i].name);
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
