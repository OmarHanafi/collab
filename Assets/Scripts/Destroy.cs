using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

  

	// Use this for initialization
	void Start () {

        Invoke("end", 3f);
	}

    private void end()
    {
        Destroy(this.gameObject);
    }
}
