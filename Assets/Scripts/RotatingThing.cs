using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingThing : MonoBehaviour {

    [SerializeField]
    private float rotFreq;

    [SerializeField]
    private float rotOffset;

    [SerializeField]
    private float rotAmp;

	void Start () {
		
	}
	
	void FixedUpdate () {
        float t = Time.timeSinceLevelLoad;
        float angle = rotOffset + rotAmp * Mathf.Sin(rotFreq * t);
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
	}
}
