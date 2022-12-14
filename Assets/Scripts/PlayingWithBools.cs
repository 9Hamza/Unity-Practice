using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingWithBools : MonoBehaviour
{
    [SerializeField] private bool activated = false;

    [SerializeField] private Transform block;

    [SerializeField] private GameObject _pepeAndCheckers;
    
    // Update is called once per frame
    void Update()
    {
        if (activated)
        {
            if (block.transform.position.y < 9)
            {
                block.Translate(0, 3 * Time.deltaTime, 0);
            }
            else
            {
                _pepeAndCheckers.SetActive(false);
            }
        }
    }

    // You can use OnTriggerStay instead of Enter if that suits you. You can do whatever that suits you (no specific way of doing things)
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            activated = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            activated = false;
        }
    }
}
