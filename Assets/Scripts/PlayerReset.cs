using UnityEngine;
using System.Collections;
using UnityEngine.ProBuilder;

public class PlayerReset : MonoBehaviour {

	public GameObject playerObject;
	public GameObject[] squirrels;

	private Vector3 playerStartPos;
	void Start() {
		squirrels = GameObject.FindGameObjectsWithTag("squirrels");
		playerStartPos = new Vector3(40.77f, -11.37f, 8.523f);
	}

	// Update is called once per frame
	void Update() {
		if (Time.timeScale == 1) {
			if (Input.GetButtonUp("R")) {
				playerObject.transform.position = playerStartPos;
			}
			else if (Input.GetKeyUp(KeyCode.N)) {
				playerObject.transform.position = playerStartPos;
				for (int i = 0; i < squirrels.Length; i++) { 
					squirrels[i].transform.position = new Vector3(57.3656f, -6.502008f, 32.52466f);
					squirrels[i].transform.rotation = new Quaternion(0, 0, 0, 0);
				}
				GetSquirrels.squirrelsCaught = 0;
			} 
		}
	}
}
