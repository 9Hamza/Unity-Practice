using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPController : MonoBehaviour
{

    // Camera
    [SerializeField] private Transform cameraTarget;
    private Camera _mainCamera;
    
    // Mouse
    [SerializeField] private bool invertMouse = false;
    [SerializeField] private float mouseSensitivity = 1f;
    [SerializeField] private float lookUpConstraint;
    [SerializeField] private float lookDownConstraint;

    // Movement
    public float MoveSpeed;
    public float RunSpeed;
    public int coinCount = 0;
    private CharacterController _characterController;
    private Vector3 _movement;
    private float _verticalRotationLimit;

    private void Start()
    {
        _mainCamera = Camera.main;
        
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // Mouse input
        Vector2 mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensitivity;

        // Rotates the player horizontally based on Mouse X input
        float yRotation = transform.rotation.eulerAngles.y + mouseInput.x;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, yRotation, transform.rotation.eulerAngles.z); // rotating the player left and right using mouse input.

        // Mouse invert preference
        float invert = (!invertMouse) ? -1f : 1f;
        _verticalRotationLimit += (mouseInput.y * invert);

        // Limits X axis rotation based on input
        _verticalRotationLimit = Mathf.Clamp(_verticalRotationLimit, lookDownConstraint, lookUpConstraint); // this acts like a limit for max and min amount our vertRotation can reach.

        // Applies rotation to the camera target // The player is doing the horizontal rotation while the camera is doing the vertical rotation.
        cameraTarget.rotation =
            Quaternion.Euler(_verticalRotationLimit, cameraTarget.eulerAngles.y, cameraTarget.eulerAngles.z);
        
        // User input for moving
        Vector3 moveForward = transform.forward * Input.GetAxisRaw("Vertical"); // the forward-facing side of the player object multiplied by vertical inputs (W and S keys).
        Vector3 moveRight = transform.right * Input.GetAxisRaw("Horizontal"); // the right-facing side of the player object multiplied by horizontal inputs (A and D keys).
        
        // set movement speed based on if the player is holding down left shift
        float currentSpeed = (Input.GetKey(KeyCode.LeftShift)) ? RunSpeed : MoveSpeed;
        
        // Generates movement
        _movement = (moveForward + moveRight).normalized * currentSpeed;
        _characterController.Move(_movement * Time.deltaTime);

    }

    private void LateUpdate()
    {
        _mainCamera.transform.position = cameraTarget.position;
        _mainCamera.transform.rotation = cameraTarget.rotation;
    }
}
