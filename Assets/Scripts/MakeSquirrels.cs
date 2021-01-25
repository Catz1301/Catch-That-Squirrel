using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeSquirrels : MonoBehaviour
{
    public int numberOfSquirrels = 4;
    public GameObject Squirrel;
    public GameObject terrainObject;
    private Terrain terrain;
    public GameObject playerObj;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberOfSquirrels; i++) {
            /*System.Random rnd = new System.Random();
            terrain = terrainObject.GetComponent<Terrain>();
            float x = Random.Range(0f + terrain.transform.position.x, terrain.terrainData.bounds.size.x);
            float y = Random.Range(0f + terrain.transform.position.y, terrain.terrainData.bounds.size.y);
            float z = terrain.terrainData.GetHeight((int) x, (int) y); //height*/
            Vector3 position = new Vector3(57.3656f, -6.502008f, 32.52466f);
            Quaternion rotation = Random.rotation;
            GameObject newSquirrel = Instantiate(Squirrel, position, rotation);
            newSquirrel.tag = "squirrels";
            //newSquirrel.AddComponent<ColorSquirrel>();
            ColorSquirrel colorSquirrel = newSquirrel.AddComponent<ColorSquirrel>();
            colorSquirrel.squirrel = newSquirrel;
            SquirrelMovement squirrelMovement = newSquirrel.AddComponent<SquirrelMovement>();
            squirrelMovement.gameObj = newSquirrel;
            squirrelMovement.PlayerObject = playerObj;
            newSquirrel.SetActive(true);
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
