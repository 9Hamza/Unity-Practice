using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovingHazard : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private Vector3 startPoint;
    [SerializeField] private Vector3 endPoint;

    // Update is called once per frame
    void Update()
    {
        // It is confusing to explain now because we will cover controlling time in future lessons.
        // The best way to explain it is, if time in your game was paused, slowed down, or sped up, Time.time will continue to count in normal seconds.
        transform.position = Vector3.Lerp(startPoint, endPoint, Mathf.PingPong(Time.time * speed, 1));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
