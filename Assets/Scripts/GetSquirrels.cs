using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetSquirrels : MonoBehaviour
{
    public static int squirrelsCaught = 0;
    public Text squirrelsCaughtText;
    public int totalSquirrels;

	void Start() {
        totalSquirrels = FindObjectOfType<MakeSquirrels>().numberOfSquirrels;
	}

	void Update() {
        squirrelsCaughtText.text = "Squirrels caught: " + squirrelsCaught.ToString() + "/" + totalSquirrels.ToString();
    }
}
