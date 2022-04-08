using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    // Player movement ------------------------------------
    //public variables that can be altered in editor.
    public float moveSpeed = 1f;
    public float jumpForce = 7f;
    public float fallSpeed = 0.01f;
    public float maxFallSpeed = -3f;
    public bool doubleJump = true;

    //private variables we will use to determine things
    private bool onGround;
    private Rigidbody rbody;

    // Game Manager
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        //getting the rigidbody so we can manipulate it
        rbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Take in inputs, we should usually use the Input Axis
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;

        //set the rigibody's velocity
        Vector3 targetDirection = new Vector3(x, 0f, z);
        targetDirection = Camera.main.transform.TransformDirection(targetDirection);
        rbody.velocity = new Vector3(targetDirection.x, rbody.velocity.y, targetDirection.z);


        //if (rbody.velocity.y < maxFallSpeed) {
        //    rbody.velocity = new Vector3(x, maxFallSpeed, z);
        //}
        
        // Alter the drag of the character when jumping/falling
        if (rbody.velocity.y < 0)
        {
            rbody.drag = -3f;
        }
        else {
            rbody.drag = 2f;
        }


        //alter the direction the character looks
        Vector3 lookdirection = rbody.velocity;
        lookdirection.y = 0;

        if(lookdirection.x != 0 || lookdirection.z != 0)
        {
            transform.forward = lookdirection;
        }

        //jumping
        //if Space bar is pressed, then jump
        //the method used here is alright for things like this, but if the player
        //holds down space bar nothing will happen
        if(Input.GetKeyDown(KeyCode.Space) && (onGround == true || doubleJump == true))
        {
            //instant jolt of energy that pushes player up
            rbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            if (onGround == false) {
                doubleJump = false;
            }
        }

        //Raytracing to detect if we are on the ground 
        // how far the ray goes
        float castDistance = 1f;

        // grab the center of our char, or their world position
        Vector3 center = transform.position;
        // lower the grabbed variable so that the ray can go below
        // the character
        // THIS VALUE WILL NEED TO BE CHANGED IF MODEL HEIGHT ISN'T 1f!
        center.y = center.y - 0.5f;
        //create the ray pointing down.
        Ray standingRay = new Ray(center, Vector3.down);
        //create a debug ray that is viewable in the scene view, not the game view
        // it is the same as our normal one
        Debug.DrawRay(transform.position, Vector3.down * castDistance, Color.red);

        // cast the ray out, and this records if the ray hits anything
        // if we do hit something, we are on ground, else we are in air
        RaycastHit hit;
        if (Physics.Raycast(standingRay, out hit, castDistance))
        {
            onGround = true;
            doubleJump = true;
        }
        else
        {
            onGround = false;
        }
    }

    //player dies
    public void PlayerDied()
    {
        
    }

}
