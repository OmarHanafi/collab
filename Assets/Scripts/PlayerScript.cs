using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

    public float thrustSpeed;
    [SerializeField] float turnSpeed;
    Rigidbody rigidBody;
    float score;
    public enum PlayerState { Alive, Dying, Transcending};
    public PlayerState playerState = PlayerState.Alive;
    [SerializeField] Text ScoreText;    

    // For moving sideways
    bool leftButtonDown = false;
    bool rightButtonDown = false;

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
            print("forward");
        }
        else
        {
            ForwardSinMovement();
            
        }
    }

    void ForwardMovement ()
    {
        Vector3 velocity = rigidBody.velocity;
        velocity.z = thrustSpeed * Time.deltaTime;
        rigidBody.velocity = velocity;
        score = transform.position.z;
        ScoreText.text = ""+(int) score;
        print(score);
    }
    void ForwardSinMovement()
    {


        print("sinus");

    }

    void SidewaysMovement()
    {
        if (leftButtonDown)
            rigidBody.AddForce(-turnSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        else if (rightButtonDown)
            rigidBody.AddForce(turnSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

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
            
            rigidBody.AddForce(0, 10000f * Time.deltaTime, 0);
            rigidBody.velocity = new Vector3(0, 0, 250f * Time.deltaTime);
            Invoke("Reload", 1f);
        }
            
    }
}
