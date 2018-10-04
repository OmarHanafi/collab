using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour {

    public GameObject Obstacle;
    [SerializeField] GameObject player;
    [SerializeField] float obstacleOffset = 50f;

    // Use this for initialization
    void Start () {
        InvokeRepeating("Spawning", 1f, 0.5f);
    }
	
	void Spawning () {
        float z = player.transform.position.z + obstacleOffset;
        for (float x = 0; x < Random.Range(3, 5); x++)
        {
            GameObject obs = Instantiate(Obstacle, new Vector3(Random.Range(-24f, 24f), Random.Range(1.5f, 15f), z), Quaternion.identity);
            Destroy(obs, 3f);
        }
    }

}
