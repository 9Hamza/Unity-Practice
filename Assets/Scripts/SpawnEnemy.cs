using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{

    [SerializeField] private Transform spawnLocation;
    [SerializeField] private GameObject enemyGameObject;
    
    // Start is called before the first frame update
    void Start()
    {
        // Make sure that the enemy is not spawned at the beginning of the game
        enemyGameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        enemyGameObject.SetActive(true);
        Debug.Log("enemy spawned!");
    }
}
