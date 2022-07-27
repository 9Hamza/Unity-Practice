using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CollidingWithStuff : MonoBehaviour
{

    // [SerializeField] private float _shrinkRate = 0.1f;
    
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // if i collide with a gameObject 
        {
            Debug.Log(gameObject.name + " collided with " + collision.gameObject.name);
            Destroy(collision.gameObject);
        }
    }

    // OnCollisionStay is like the Update method of collisions. OnCollisionEnter is called as soon as two physical objects make contact.
    // OnCollisionStay is always being called so long as the two game objects are touching and stop when they break contact.
    // private void OnCollisionStay(Collision collisionInfo)
    // {
    //     Debug.Log(gameObject.name + " is still touching " + collisionInfo.gameObject.name);
    //     collisionInfo.gameObject.transform.localScale -= (new Vector3(_shrinkRate, _shrinkRate,_shrinkRate));
    // }
}
