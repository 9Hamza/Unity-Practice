using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowSize : MonoBehaviour
{
    [SerializeField] private float changeRate = 0.1f;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log(collision.gameObject.name + " collided with " + gameObject.name );
            collision.gameObject.transform.localScale += new Vector3(changeRate, changeRate, changeRate) * Time.deltaTime; 
        }
    }

    private void OnTriggerEnter(Collider other) // Whenever you enter the collider that has an "isTrigger" enabled.
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log(other.gameObject.name + " entered the trigger of " + gameObject.name );
            other.gameObject.transform.localScale += new Vector3(changeRate, changeRate, changeRate) * Time.deltaTime; 
        }
    }

    // private void OnCollisionStay(Collision collisionInfo)
    // {
    //     if (collisionInfo.gameObject.CompareTag("Player"))
    //     {
    //         Debug.Log(collisionInfo.gameObject.name + " is still touching " + gameObject.name);
    //     }
    // }

    // private void OnCollisionStay(Collision collisionInfo)
    // {
    //     collisionInfo.gameObject.transform.localScale += Vector3.one * changeRate;
    // }
}
