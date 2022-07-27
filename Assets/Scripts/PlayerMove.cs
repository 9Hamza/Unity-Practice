using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerMove : MonoBehaviour
{
   public float speed = 2.0f;
   public int coinCount = 0;

   [SerializeField] private Camera camera;

   private CharacterController _cc;
   
   private Vector3 _movement;
   
   private float gravity = 9.8f;

   private int _playerHealth = 3;

   private void HandleMovement()
   {
      var direction = GetMovement(); // is it bad to store V3 in a var?
      var rot = camera.transform.rotation.eulerAngles;

      rot.x = 0f;
      Quaternion q = Quaternion.Euler(rot);
      rot = q * direction;

      _cc.Move(rot);
   }

   private Vector3 GetMovement()
   {
      // Since we are using rb.velocity, we won't need to use Time.deltaTime since it will interfere with the physics of the rigidbody
      float horizontalInput = Input.GetAxisRaw("Horizontal") * speed  * Time.deltaTime;
      float verticalInput = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;

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
      HandleMovement();
      
      // _rb.velocity = movement;

      // transform.Translate(movement); // We don't want to use Translate since it is not meant for moving objects in four directions

      // transform.position += new Vector3(0, 0, speed * Time.deltaTime);
      // Debug.Log($"{Input.GetAxisRaw("Horizontal")}"); // current value of Horizontal input mapped to A-D
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
      // _cc.Move(_movement);
   }
}
