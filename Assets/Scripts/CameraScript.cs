using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour {

    [SerializeField] PlayerScript player;
    float zOffset;
    Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        zOffset = player.transform.position.z - transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
        if(player.playerState == PlayerScript.PlayerState.Alive)
        {
            CameraFollow();
        }
    }

    void CameraFollow ()
    {
        transform.position = new Vector3(player.transform.position.x,
                                             transform.position.y,
                                             player.transform.position.z - zOffset);
    }

    public void CameraRotateLeft()
    {
        animator.SetTrigger("Left");
        
    }

    public void CameraRotateRight()
    {
        animator.SetTrigger("Right");
    }
}
