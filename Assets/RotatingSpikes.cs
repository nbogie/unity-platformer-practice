using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingSpikes : MonoBehaviour {
    [SerializeField]
    private float rotSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	void FixedUpdate () {
        transform.Rotate(Vector3.back, rotSpeed * Time.fixedDeltaTime);	
	}
}
