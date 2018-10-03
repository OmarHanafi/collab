using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour {

    public GameObject Obstacle;


    // Use this for initialization
    void Start () {
        for (float z = 10; z < 1600; z += 15)
        {
            //5 per line
            for (float x = 0; x < 5; x++)
            {
                Instantiate(Obstacle, new Vector3(Random.Range(-23.5f, 23.5f),1.5f, 400f + z), Quaternion.identity);

            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
