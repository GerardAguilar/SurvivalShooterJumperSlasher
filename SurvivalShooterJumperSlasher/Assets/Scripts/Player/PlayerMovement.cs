using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;

    Vector3 movement;
    Animator anim;
    Rigidbody playerRigidbody;
    int floorMask;
    float camRayLength = 100f;

    void Awake() {
        floorMask = LayerMask.GetMask("Floor");
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        float h = Input.GetAxisRaw("Horizontal"); //just -1,0,1 instead of -1...-0.5...0...0.5...1
        float v = Input.GetAxisRaw("Vertical");
    }

    void Move(float h, float v) {
        movement.Set(h, 0f, v);
        movement = movement.normalized * speed * Time.deltaTime;//keeps diagonal movement the same length as horizontal and vertical
        playerRigidbody.MovePosition(transform.position + movement);
    }

    void Turning() {
        //Finished at 26:57
    }
}
