using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour {

    public GameObject Obstacle;
    [SerializeField] GameObject player;
    [SerializeField] float obstacleOffset = 100f;

    // Use this for initialization
    void Start () {
        InvokeRepeating("Spawning", 1f, 0.5f);
    }
	
	void Spawning () {
        float z = player.transform.position.z + obstacleOffset;
        for (float x = 0; x < Random.Range(1, 5); x++)
        {
            Instantiate(Obstacle, new Vector3(Random.Range(-30f, 30f), 1.5f, z), Quaternion.identity);
        }
    }
}
