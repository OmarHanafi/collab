using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [SerializeField] PlayerScript player;
    float zOffset;

	// Use this for initialization
	void Start () {
        zOffset = player.transform.position.z - transform.position.z;
        print(zOffset);
	}
	
	// Update is called once per frame
	void Update () {
        if(player.playerState == PlayerScript.PlayerState.Alive)
        {
            CameraMovement();
        }
    }

    void CameraMovement ()
    {
        transform.position = new Vector3(player.transform.position.x,
                                             transform.position.y,
                                             player.transform.position.z - zOffset);
    }
}
