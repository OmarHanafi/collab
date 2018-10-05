using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipes : MonoBehaviour {


    bool down = false;
    bool up = false;


    private void FixedUpdate()
    {
        if(Input.touchCount >0)
        {
            print("touching");
        }
        else
        {
            print("released");
        }
    }


}
