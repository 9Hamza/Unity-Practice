using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    [SerializeField] private bool isReady = false;
    [SerializeField] private Transform teleportTo;
    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Teleport!");
            collision.gameObject.GetComponent<CharacterController>().enabled = false;
            collision.gameObject.transform.position = teleportTo.position;
            collision.gameObject.GetComponent<CharacterController>().enabled = true;
        }
    }
    

    private void OnTriggerExit(Collider other)
    {
        
    }
}
