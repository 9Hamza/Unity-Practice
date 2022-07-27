using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AffectPlayer : MonoBehaviour
{

    private PlayerMove _playerMoveScript;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _playerMoveScript = other.GetComponent<PlayerMove>(); // Get a reference to the script PlayerMove

            _playerMoveScript.speed = 15f;
        }
    }
}
