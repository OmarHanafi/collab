using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

    public float thrustSpeed;
    [SerializeField] float turnSpeed;
    Rigidbody rigidBody;

    // Player State
    public enum PlayerState { Alive, Dying, Transcending};
    public PlayerState playerState = PlayerState.Alive;

    // Score
    float score;
    [SerializeField] Text ScoreText;

    [SerializeField] CameraScript cameraScript;  // Camera Script Reference
    [SerializeField] UIScript uiScript;  // UI Script Reference

    // For moving sideways
    bool leftButtonHeld = false;
    bool rightButtonHeld = false;


    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
    void Update()
    {
        
    }

	void FixedUpdate () {
        if (playerState == PlayerState.Alive)
        {
            ForwardMovement();
            SidewaysMovement();
        }
    }

    void ForwardMovement ()
    {
        Vector3 velocity = rigidBody.velocity;      // Moving the object
        velocity.z = thrustSpeed * Time.deltaTime;
        rigidBody.velocity = velocity;

        score = transform.position.z;       // Updating the score
        uiScript.updateScore((int)score);
        //print(score);
    }

    void SidewaysMovement()
    {
        SlowDown();

        if (leftButtonHeld)
        {
            rigidBody.AddForce(-turnSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        else if (rightButtonHeld)
        {
            rigidBody.AddForce(turnSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
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
        leftButtonHeld = true;
        uiScript.LeftArrowDown();
        cameraScript.CameraRotateLeft();
    }

    public void RightButtonDown()
    {
        rightButtonHeld = true;
        uiScript.RightArrowDown();
        cameraScript.CameraRotateRight();
    }

    public void LeftButtonUp()
    {
        leftButtonHeld = false;
        uiScript.LeftArrowUp();
    }

    public void RightButtonUp()
    {
        rightButtonHeld = false;
        uiScript.RightArrowUp();
    }

    public void SlowDown()
    {
        if (!leftButtonHeld && !rightButtonHeld && !Input.GetKey(KeyCode.Q) && !Input.GetKey(KeyCode.D))
        {
            Vector3 velocity = rigidBody.velocity;
            velocity.x *= 0.9f;
            rigidBody.velocity = velocity;
        }
    }

    void Reload()
    {
        SceneManager.LoadScene(0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collider = collision.gameObject;
        if (collider.tag == "Obstacle")
        {
            print("dead");
            playerState = PlayerState.Dying;
            if(collider.gameObject.GetComponent<Rigidbody>()!=null)
            {
                collider.gameObject.GetComponent<Rigidbody>().AddForce(0, 10000f * Time.deltaTime, 0);
            }
            Invoke("Reload", 1f);
        }
            
    }
}
