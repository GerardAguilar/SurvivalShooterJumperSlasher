using UnityEngine;
using System.Collections;

public class FloorScript : MonoBehaviour {

    PlayerMovement playerMovement;

    void Awake() {
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            Debug.Log("Player has touched the floor!");
            playerMovement.isFalling = false;
        }
    }
}
