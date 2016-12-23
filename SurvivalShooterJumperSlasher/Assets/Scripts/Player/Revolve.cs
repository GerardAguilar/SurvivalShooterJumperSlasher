/*
Centralizing works! Now just need to get the acceleration and angle down.
*/

using UnityEngine;
using System.Collections;

public class Revolve : MonoBehaviour {

    
    public Transform focus;

    float acceleration;
    float speed;
    Quaternion originalRotation;
    Vector3 originalPosition;

    void Start() {
        focus = GameObject.Find("Player").transform;
    }

    void OnEnable() {
        acceleration = 1;
        speed = 200;
        originalRotation = transform.rotation;
        originalPosition = transform.localPosition;
    }

	// Use this for initialization
	void FixedUpdate () {
        transform.RotateAround(new Vector3(focus.position.x, focus.position.y, focus.position.z), focus.up, speed*acceleration*Time.deltaTime);
        if (acceleration > 9)
        {
            gameObject.SetActive(false);
        }
        else {
            acceleration = acceleration * 1.2f;
        }
	}

    void OnDisable() {//this offset should be based on the character's current rotation
        //Resetting on disable might not be a good idea. The reset should be on Enable
        //What to do with the initial run?
        transform.rotation = originalRotation;
        transform.localPosition = originalPosition;
    }

}
