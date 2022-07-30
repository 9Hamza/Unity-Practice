using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{

    private PlayerMove _playerMoveScript;

    [SerializeField] private float speedBoost = 10f;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _playerMoveScript = other.GetComponent<PlayerMove>(); // Get a reference to the script PlayerMove

            _playerMoveScript.MoveSpeed += speedBoost;
            _playerMoveScript.RunSpeed += speedBoost;
            
            // In order for this trigger to be used only once in the game, we do this
            // There are other ways to do this (e.g. using bools in an if statement)
            gameObject.SetActive(false);
        }
    }
}
