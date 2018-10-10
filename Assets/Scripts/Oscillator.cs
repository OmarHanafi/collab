using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour {
    Vector3 startingPos;
    [SerializeField] Vector3 movementVector;

    [SerializeField] float speed;


    void Start () {
        startingPos = transform.position;
	}
	

	void FixedUpdate () {

        Vector3 offset = Mathf.Sin(Time.time*speed) * movementVector * Time.deltaTime;
        transform.position = startingPos + offset;
	}
}
