using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class SC_FPSController : MonoBehaviour
{
    private static float walkSpeed = 12.5f;
    private static float sprintSpeed = 20.0f;
    private static float crouchSpeed = 7.5f;
    private Animator animator;
    private Vector3 palyer_OriginalCameraPosition;

    public float playerSpeed = walkSpeed;

    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 90.0f;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    
    public bool canMove = true;
    public bool standing = true;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerSpeed = walkSpeed;
        playerCamera = Camera.main;
        palyer_OriginalCameraPosition = playerCamera.transform.localPosition;
    }

    void Update()
    {
        // We are grounded, so recalculate move direction based on axes
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        // Press Left Shift to run
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? playerSpeed * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? playerSpeed * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        // Jump
        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        // Crouch
        if (Input.GetButton("Crouch") && canMove && characterController.isGrounded)
        {
            playerSpeed = crouchSpeed;
            standing = false;
        }
        if (Input.GetButtonUp("Crouch") && canMove)
        {
            playerSpeed = walkSpeed;
            standing = true;
        }

        //Sprint
        if (Input.GetButton("Sprint") && canMove && standing && characterController.isGrounded)
        {
            playerSpeed = sprintSpeed;
        }
        if (Input.GetButtonUp("Sprint") && canMove)
        {
            playerSpeed = walkSpeed;
        }



        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        // Player and Camera rotation
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }

    public void UpdateCameraPos()
    {
        Vector3 newCameraPosition;

        newCameraPosition = playerCamera.transform.localPosition;
        newCameraPosition.y = palyer_OriginalCameraPosition.y;

        playerCamera.transform.localPosition = newCameraPosition;
    }
}