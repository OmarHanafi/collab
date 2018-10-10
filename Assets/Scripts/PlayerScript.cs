using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

    public float thrustSpeed;
    float turnSpeed = 10;
    Rigidbody rigidBody;
    float score;
    public enum PlayerState { Alive, Dying, Transcending};
    

    public PlayerState playerState = PlayerState.Alive;
    
    [SerializeField] Text ScoreText;    


    


    private bool leftButtonHeld = false;
    private bool rightButtonHeld = false;

    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody>();

        //turning = turning.Nn;


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
        // Moving the object
        Vector3 velocity = rigidBody.velocity;      
        velocity.z = thrustSpeed * Time.deltaTime;
        rigidBody.velocity = velocity;

        // Updating the score
        score = transform.position.z;       
        ScoreText.text = ""+(int) score;
        //print(score);
    }


    public void LeftButtonDown()
    {
        leftButtonHeld = true;
    }
    public void LeftButtonUp()
    {
        leftButtonHeld = false;
    }
    public void RightButtonDown()
    {
        rightButtonHeld = true;
    }
    public void RightButtonUp()
    {
        rightButtonHeld = false;
    }


    public void SidewaysMovement()
    {
        if (leftButtonHeld)
        {
            turn(-1);
        }
        else if (rightButtonHeld)
        {
            turn(1);
        }

        // For computer testing
        if (Input.GetKey(KeyCode.Q))                                       
        {
            turn(-1);
        }
        else if (Input.GetKey(KeyCode.D))                                        
        {
            turn(1);
        }
        
    }




    private void turn(int direction)
    {
        Vector3 actualPos = transform.position;
        actualPos.x += direction * turnSpeed * Time.deltaTime;
        transform.position = actualPos;
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
