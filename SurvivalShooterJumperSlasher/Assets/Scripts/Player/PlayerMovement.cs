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

        Move(h, v);
        Turning();
        Animating(h, v);

    }

    void Move(float h, float v) {
        movement.Set(h, 0f, v);
        movement = movement.normalized * speed * Time.deltaTime;//keeps diagonal movement the same length as horizontal and vertical
        playerRigidbody.MovePosition(transform.position + movement);
    }

    void Turning() {
        //Finished at 26:57
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit floorHit;

        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask)) {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f; //flatten the playerToMouse onto the floor

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);//z-axis is by default the forward vector
            playerRigidbody.MoveRotation(newRotation);
        }
    }

    void Animating(float h, float v) {
        bool walking = h!= 0f || v != 0f;//senses movement in the horizontal or the vertical
        anim.SetBool("IsWalking", walking);
        //issues with animating. 09DEC2016 8:55am
    }
}
