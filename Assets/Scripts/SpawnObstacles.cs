using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour {

    public GameObject Obstacle;
    public GameObject player;

    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        
            
            for (float x = 0; x < 1; x++)
            {
                Instantiate(Obstacle, new Vector3(Random.Range(-23.5f, 23.5f), Random.Range(2f, 10f), player.transform.position.z+30), Quaternion.identity);

            }
        }
    
}
