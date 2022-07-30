using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovingHazard : MonoBehaviour
{

    [SerializeField] private float speed;
    // private Vector3 _startPoint;
    [SerializeField] private Vector3 startPoint;
    [SerializeField] private Vector3 endPoint;

    private void Start()
    {
        // _startPoint = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        // If time in your game was paused, slowed down, or sped up, Time.time will continue to count in normal seconds.
        transform.localPosition = Vector3.Lerp(startPoint, endPoint, Mathf.PingPong(Time.time * speed, 1));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
