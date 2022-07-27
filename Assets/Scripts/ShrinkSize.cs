using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkSize : MonoBehaviour
{
    [SerializeField] private float changeRate = 10f;
    private void OnTriggerEnter(Collider other) // Whenever you enter the collider that has an "isTrigger" enabled.
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log(other.gameObject.name + " entered the trigger of " + gameObject.name );
            other.gameObject.transform.localScale -= new Vector3(changeRate, changeRate, changeRate) * Time.deltaTime; 
        }
    }
}
