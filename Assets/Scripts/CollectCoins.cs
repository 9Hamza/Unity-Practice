using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollectCoins : MonoBehaviour
{

   private PlayerMove _playerMove;
   
   private void OnTriggerEnter(Collider other)
   {
      if (other.gameObject.CompareTag("Player"))
      {
         _playerMove = other.GetComponent<PlayerMove>();
         _playerMove.coinCount++;
         Debug.Log("Coins collected: " + _playerMove.coinCount);
         Destroy(gameObject);
      }
   }
}
