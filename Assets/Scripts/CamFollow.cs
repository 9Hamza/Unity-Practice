using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target;

    public Vector3 offset;

    private void Start()
    {
        transform.position = target.position;
    }

    private void LateUpdate()
    {
        transform.position = target.position + offset; // pos of cam = pos of player + offset
        transform.LookAt(target); // look at the player
    }
}
