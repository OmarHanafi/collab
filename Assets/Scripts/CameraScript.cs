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

    public void RotateLeft()
    {
        animator.SetBool("Left",true);
        
    }

    public void RotateRight()
    {
        animator.SetBool("Right",true);
    }

    public void StopRotateLeft()
    {
        animator.SetBool("Left", false);
    }

    public void StopRotateRight()
    {
        animator.SetBool("Right", false);
    }

}
