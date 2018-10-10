using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour {

    public GameObject Obstacle;
    [SerializeField] GameObject player;
    [SerializeField] float obstacleOffset = 50f;

    // Use this for initialization
    void Start () {
        InvokeRepeating("Spawning", 1f, 0.4f);
    }
	
	void Spawning () {
        float z = player.transform.position.z + obstacleOffset;
        float nbObstacles = Random.Range(3, 5);
        float step = 48 / nbObstacles;
        for(int i=0; i<nbObstacles; i++)
        {
            float min = -24 + step * i + 2f;
            float max = min + step - 2f;
            GameObject obs = Instantiate(Obstacle, new Vector3(Random.Range(min, max), Random.Range(1.5f, 15f), z), Quaternion.identity);
            Destroy(obs, 3f);
        }
    }

}
