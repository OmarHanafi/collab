using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour {
    Vector3 startingPos;
    [SerializeField] Vector3 movementVector = new Vector3(10f, 10f, 10f);
    [SerializeField] [Range(0, 1)] float Factor;
    [SerializeField] float period = 2f;


	void Start () {
        startingPos = transform.position;
	}
	

	void Update () {
        if (period <= Mathf.Epsilon) return;
        float cycles = Time.time / period;
        const float tau = Mathf.PI * 2f;
        float rawSinWave = Mathf.Sin(cycles * tau);

        print(rawSinWave);

        Factor = rawSinWave / 2f + 0.5f;


        Vector3 offset = Factor * movementVector;
        transform.position = startingPos + offset;
	}
}
