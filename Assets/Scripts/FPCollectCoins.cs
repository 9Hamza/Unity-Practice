using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPCollectCoins : MonoBehaviour
{
    private FPController _playerMove;
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _playerMove = other.GetComponent<FPController>();
            _playerMove.coinCount++;
            Debug.Log("Coins collected: " + _playerMove.coinCount);
            Destroy(gameObject);
        }
    }
}
