using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public CharacterController controller;
    public float speed = 10f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public float jumpHeight = 5f;
    public Transform cam;
    public Vector3 velocity;
    public float grav = -4.9f;
    public Transform groundCheck;
    public float groundDistance;
    public LayerMask groundMask;
    public bool onGround;
    // Update is called once per frame
    void Update()
    {
        //constantly checks if player is on the ground
        onGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(onGround && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //directional input from player
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        //determines player/camera rotation based on movement
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        //jumping
        if(Input.GetButtonDown("Jump") && onGround)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * grav);
        }

        //adding gravity to the player
        velocity.y += grav * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (groundCheck.position.y < -10)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
