using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipes : MonoBehaviour
{

    bool clicking;
    Vector2 startTouch;
    Vector2 endTouch;
    // Use this for initialization
    void Start()
    {
        clicking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clicking = true;
            startTouch = Input.mousePosition;
            
        }
        if (Input.GetMouseButtonUp(0))
        {
            clicking = false;
            endTouch = Input.mousePosition;
            


            if (startTouch.y + 100 < endTouch.y)
            {
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                //print(player.transform.position.y);
                if(player.transform.position.y<1)
                {
                    Rigidbody rb = player.GetComponent<Rigidbody>();
                    rb.AddForce(0, 500 * Time.deltaTime, 0, ForceMode.VelocityChange);
                }
            }
        }

    }
}