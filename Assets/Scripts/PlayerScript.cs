using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public float thrustSpeed;
    [SerializeField] float turnSpeed;
    Rigidbody rigidBody;
    enum State { Alive, Dying, Transcending};
    State state = State.Alive;

    // For moving sideways
    bool leftButtonDown = false;
    bool rightButtonDown = false;

    // Camera attributes
    float cameraOffset;
    [SerializeField] GameObject mainCamera;

    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody>();
        cameraOffset = transform.position.z - mainCamera.transform.position.z;
	}
	
	// Update is called once per frame
    void Update()
    {

    }

	void FixedUpdate () {
        if (state == State.Alive)
        {
            ForwardMovement();
            SidewaysMovement();
            CameraMovement();
        }      
    }

    void ForwardMovement ()
    {
        transform.position = new Vector3(transform.position.x,
                                             transform.position.y, 
                                             transform.position.z + thrustSpeed * Time.deltaTime);
    }

    void CameraMovement()
    {
        mainCamera.transform.position = new Vector3(transform.position.x,
                                             mainCamera.transform.position.y,
                                             transform.position.z - cameraOffset);
    }

    void SidewaysMovement()
    {
        if (leftButtonDown)
        {
            rigidBody.AddForce(-turnSpeed * Time.deltaTime, 0, 0);
        } else if (rightButtonDown)
        {
            rigidBody.AddForce(turnSpeed * Time.deltaTime, 0, 0);
        }

        // For computer testing
            if (Input.GetKey(KeyCode.Q))
                rigidBody.AddForce(-turnSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            else if (Input.GetKey(KeyCode.D))
                rigidBody.AddForce(turnSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        // End
    }

    public void LeftButtonDown()
    {
        leftButtonDown = true;
    }

    public void RightButtonDown()
    {
        rightButtonDown = true;
    }

    public void LeftButtonUp()
    {
        leftButtonDown = false;
    }

    public void RightButtonUp()
    {
        rightButtonDown = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collider = collision.gameObject;
        if (collider.tag == "Obstacle")
        {
            state = State.Dying;
            collider.gameObject.GetComponent<Rigidbody>().AddForce(0, 1000f * Time.deltaTime, 0);
            rigidBody.AddForce(0, 10000f * Time.deltaTime, 0);
        }
            
    }
}
