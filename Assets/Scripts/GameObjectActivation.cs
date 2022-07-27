using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameObjectActivation : MonoBehaviour
{
    [SerializeField] private GameObject testBlock;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            testBlock.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
