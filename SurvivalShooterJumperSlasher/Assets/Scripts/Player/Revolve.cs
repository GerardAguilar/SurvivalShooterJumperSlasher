/*
Centralizing works! Now just need to get the acceleration and angle down.
*/

using UnityEngine;
using System.Collections;

public class Revolve : MonoBehaviour {

    public Transform focus;
    public Quaternion playerRotation;
    public BladePool bladePool;

    float acceleration;
    float speed;
    Quaternion originalRotation;
    Vector3 originalPosition;

    public GameObject target;
    public EnemyHealth test;
    public int damagePerSlash;

    void Start() {
        //focus = GameObject.Find("Player").transform;
        //bladePool = GameObject.Find("BladePool").GetComponent<BladePool>();
        damagePerSlash = 1000;
        
    }

    void OnEnable() {
        focus = GameObject.Find("Player").transform;
        acceleration = 1;
        speed = 200;
        //originalRotation = transform.rotation;
        transform.localRotation = Quaternion.Euler(focus.rotation.x, focus.rotation.y-30f, focus.rotation.z);

        originalPosition = transform.localPosition;
    }

    //void OnCollisionEnter(Collision other)
    //{
    //    Debug.Log("hi");
        //Debug.Log(other.gameObject);
        //if (other.gameObject.CompareTag("Enemy"))
        //{
        //    target = other.gameObject;
        //    test = target.GetComponent<EnemyHealth>();
        //    test.TakeDamage(damagePerSlash, target.transform.position);
        //    Debug.Log(target.tag);

        //}
    //}

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
        //transform.rotation = playerRotation;
        transform.localPosition = originalPosition;
        
    }

}
