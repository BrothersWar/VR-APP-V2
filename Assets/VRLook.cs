using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRLook : MonoBehaviour
{
    public Transform vrCamera;
    public float speed = 3.0f;
    public bool moveForward;
    private float gravity = 10f;
    public bool canJump;
    private CharacterController cc;
    Rigidbody rb;

    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 3.0f;
    private float gravityValue = -9.81f;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        groundedPlayer = cc.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }


        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (gameObject.transform.position.y < -50f)
        { 
            PlayerManager.gameOver = true;
        }

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        cc.Move(playerVelocity * Time.deltaTime);

        if (Input.GetButtonDown("Fire1"))
        {
            moveForward = true;
        }

        if (Input.GetButtonDown("Fire1") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }


        if (moveForward)
        {
            Vector3 forward = vrCamera.TransformDirection(Vector3.forward);
            cc.SimpleMove(forward * speed);
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            print("obstacle32131");
            PlayerManager.gameOver = true;
        }
    }
}
