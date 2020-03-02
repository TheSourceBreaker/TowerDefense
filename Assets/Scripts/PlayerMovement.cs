using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float desiredSize;
    public float sizeSpeed = 6f;

    public Transform groundCheck;
    public float groundDistance = 0.44f;
    public LayerMask groundMask;

    private Vector3 newSize;
    private Vector3 mainSize;
    private Vector3 newGCSize;
    private Vector3 mainGCSize;
    private Vector3 velocity;
    bool isGrounded;

    void Start()
    {
        mainSize = controller.transform.localScale;
        newSize = new Vector3(1f, desiredSize , 1f);
    }

    void Update()
    {
        newGCSize = groundCheck.transform.position;
        newGCSize.y = newGCSize.y - 0.2f;
        mainGCSize = newGCSize;
        mainGCSize.y = mainGCSize.y + 0.2f;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            controller.transform.localScale = Vector3.Lerp(controller.transform.localScale,newSize, sizeSpeed * Time.deltaTime);
            groundCheck.transform.position = newGCSize;
        }
        else
        {
            controller.transform.localScale = Vector3.Lerp(controller.transform.localScale, mainSize, sizeSpeed * Time.deltaTime);
            groundCheck.transform.position = mainGCSize;
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0.4)
        {
            velocity.y = 0.2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawSphere(groundCheck.transform.position, groundDistance);

    }
}
