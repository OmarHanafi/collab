using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    [SerializeField] float thrustSpeed = 50f;
    [SerializeField] float turnSpeed = 2000f;
    Rigidbody rigidBody;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 position = transform.position;
        position.Set(position.x, position.y, position.z + thrustSpeed * Time.deltaTime);
        transform.position = position;

        if (Input.GetMouseButton(0))
        {
            if(Input.mousePosition.x < 120)
            {
                rigidBody.AddForce(-turnSpeed * Time.deltaTime,0, 0);
            } else if (Input.mousePosition.x > 230)
            {
                rigidBody.AddForce(turnSpeed * Time.deltaTime,0, 0);
            }
        }
	}

    void Movement ()
    {

    }
}
