using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
   [SerializeField] private Transform teleportTo;
   
   public float MoveSpeed = 10.0f;
   public float RunSpeed = 20.0f;
   public int coinCount = 0;

   [SerializeField] private Camera camera;

   private CharacterController _cc;
   
   private Vector3 _movement;
   
   private float gravity = 9.8f;

   private int _playerHealth = 3;

   // private Rigidbody _rigidbody;

   private void HandleMovementCC()
   {
      var direction = GetMovement(); // is it bad to store V3 in a var?
      var rot = camera.transform.rotation.eulerAngles;

      rot.x = 0f;
      Quaternion q = Quaternion.Euler(rot);
      rot = q * direction;

      // _rigidbody = GetComponent<Rigidbody>();
      // _rigidbody.velocity = direction;
      _cc.Move(rot);
   }

   private void HandleMovementTranslate()
   {
      // set movement speed based on if the player is holding down left shift
      float currentSpeed = (Input.GetKey(KeyCode.LeftShift)) ? RunSpeed : MoveSpeed;
      
      float horizontalInput = Input.GetAxisRaw("Horizontal") * currentSpeed  * Time.deltaTime;
      float verticalInput = Input.GetAxisRaw("Vertical") * currentSpeed * Time.deltaTime;
   
      _movement = new Vector3(horizontalInput, 0, verticalInput);
      // _movement = new Vector3(horizontalInput, verticalInput, 0);
      
      transform.Translate(_movement);
   }

   private Vector3 GetMovement()
   {
      // set movement speed based on if the player is holding down left shift
      float currentSpeed = (Input.GetKey(KeyCode.LeftShift)) ? RunSpeed : MoveSpeed;
      
      // Since we are using rb.velocity, we won't need to use Time.deltaTime since it will interfere with the physics of the rigidbody
      float horizontalInput = Input.GetAxisRaw("Horizontal") * currentSpeed  * Time.deltaTime;
      float verticalInput = Input.GetAxisRaw("Vertical") * currentSpeed * Time.deltaTime;

      _movement = new Vector3(horizontalInput, 0, verticalInput);
      _movement.y -= gravity * Time.deltaTime;
      
      return _movement;
   }
   private void Start()
   {
      _cc = GetComponent<CharacterController>();
   }

   private void Update()
   {
      HandleMovementCC();

      if (gameObject.transform.position.y < -5)
      {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
      }
      
      // HandleMovementTranslate();
      
      // _rb.velocity = movement;
   }

   private void OnCollisionEnter(Collision collision)
   {
      if (collision.gameObject.CompareTag("Hazard"))
      {
         _playerHealth--;
      }
   }

   private void OnCollisionExit(Collision other)
   {
      if (other.gameObject.CompareTag("Hazard"))
      {
         Debug.Log("I probably shouldn't have touched that. " + _playerHealth);
      }
   }

   private void FixedUpdate()
   {  
      // This didn't really work as intended
      // _cc.Move(_movement);
   }
}
