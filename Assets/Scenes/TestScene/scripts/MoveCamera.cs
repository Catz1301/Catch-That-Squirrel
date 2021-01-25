using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public GameObject playerCam;
    public float scale = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        // Movement
        if (Input.GetKeyDown(KeyCode.W)) {
            playerCam.transform.position += transform.forward;
        }
        else if (Input.GetKeyDown(KeyCode.A)) {
            playerCam.transform.position -= transform.right;
        }
        else if (Input.GetKeyDown(KeyCode.S)) {
            playerCam.transform.position -= transform.forward;
        }
        else if (Input.GetKeyDown(KeyCode.D)) {
            playerCam.transform.position += transform.right;
        }

        // Looking
        if (Input.GetKey(KeyCode.LeftArrow)) {
            playerCam.transform.Rotate(new Vector3(0, (float) -scale * Time.deltaTime, 0));
            // Z, X, Y
        }
        else if (Input.GetKey(KeyCode.RightArrow)) {
            playerCam.transform.Rotate(new Vector3(0, (float) scale * Time.deltaTime, 0));
            // Z, X, Y
        }

    }
}
