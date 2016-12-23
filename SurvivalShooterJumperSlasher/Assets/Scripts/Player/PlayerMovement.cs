using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;
    public float jumpStrength = 10f;
    public bool isFalling;
    public float x;
    public float y;
    public float z;
    public Vector3 jumpMove = new Vector3();
    public Vector3 jumpMove2 = new Vector3();

    Vector3 movement;
    Animator anim;
    Rigidbody playerRigidbody;
    Transform playerTransform;
    int floorMask;
    float camRayLength = 100f;
    
    

    void Awake() {
        floorMask = LayerMask.GetMask("Floor");
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
        playerTransform = GetComponent<Transform>();
        isFalling = false;
    }

    void Update() {
        //moved jump functionality to FixedUpdate()
        
    }

    void FixedUpdate() {
        float h = Input.GetAxisRaw("Horizontal"); //just -1,0,1 instead of -1...-0.5...0...0.5...1
        float v = Input.GetAxisRaw("Vertical");

        //if (!isFalling)
        //{
            Move(h, v);
            Turning();
            Animating(h, v);
        //}

        //Jump method 1 = add force, free movement when up in the air
        //jumping should be based on where you're facing. Currently, the bottom feels too floaty.
        if (Input.GetButton("Jump") && isFalling == false)
        {
            isFalling = true;
            Debug.Log("Jump");
            playerRigidbody.AddForce(0, 1, 0, ForceMode.Impulse);
        }

        //Jump method 2 - is not working. 
        //Attempting to extrapolate x and z coordinates based on player y rotation
        //Maybe it's with MovePosition
        //if (Input.GetButton("Jump") && isFalling == false)
        //{
        //    isFalling = true;
        //    Debug.Log("Jump2");
        //    //now how to calculate based on angle
        //    //x = specific width of camera view
        //    //y = height of jump
        //    //z = specific height of camera view

        //    if (playerTransform.localRotation.y < 0) {
        //        x = 2f * Mathf.Tan(playerTransform.localRotation.y);
        //        //x = 5f;
        //        y = 3f;
        //        //z = 5f;
        //        z = 2f * Mathf.Sin(playerTransform.localRotation.y);
        //    }
        //    else{
        //        x = -2f * Mathf.Tan(playerTransform.localRotation.y);
        //        y = 3f;
        //        z = -2f * Mathf.Sin(playerTransform.localRotation.y);
        //    }



        //    jumpMove.Set(x, y, z);
        //    //jumpMove = jumpMove.normalized;
        //    playerRigidbody.MovePosition(transform.position + jumpMove);


        //}

        //Jump is complicated. Jump towards facing or moving?

        //Jump method3 - generate a vector by quaternion
        //if (Input.GetButton("Jump") && isFalling == false)
        //{
        //    isFalling = true;
        //    Quaternion rot = Quaternion.AngleAxis(playerTransform.rotation.y, Vector3.up);
        //    Vector3 forward = Vector3.forward;
        //    jumpMove2 = rot * forward;
        //    playerRigidbody.AddForce(x, y, z, ForceMode.Impulse);
        //}

        //Jump method4 - translate y rotation to x and z values
        //z is up and down, x is right and left
        //modify public x, y, z in Unity
        //if (Input.GetButton("Jump") && isFalling == false)
        //{
        //    playerRigidbody.AddForce(x, y, z, ForceMode.Impulse);
        //}
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
        bool walking = h != 0f || v != 0f;//senses movement in the horizontal or the vertical
        anim.SetBool("IsWalking", walking);
        //issues with animating. 09DEC2016 8:55am
        if (walking)
        {
            anim.SetFloat("Speed", 1);
        }
        else {
            anim.SetFloat("Speed", 0);
        }
        
    }
}
