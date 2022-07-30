using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HazardFollow : MonoBehaviour
{

    [SerializeField] private Transform playerLocation;
    // [SerializeField] private float moveSpeed = 0.1f;

    private void Update()
    {
        Vector3 direction = playerLocation.position - transform.position;
        transform.LookAt(playerLocation);
        

        if (playerLocation.position.z < 18)
        {
            transform.position += direction * Time.deltaTime * 0.5f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("you died!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    
}
