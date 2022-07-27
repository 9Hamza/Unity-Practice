using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfStatementsDemo : MonoBehaviour
{

    private int number = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(number);
        // GetKey runs the code like an Update method (all the time), while GetKeyDown runs it just once upon action.
        if (Input.GetKeyDown(KeyCode.Alpha1) && Input.GetKeyDown(KeyCode.Alpha2))
        {
            number++;
        }
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.X))
        {
            number = 0;
        }
    }
}
